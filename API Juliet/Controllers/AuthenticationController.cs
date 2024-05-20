/*
 * Author: Johan Ahlqvist
 */

using API_Juliet.Constants;
using API_Juliet.Models;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Mäklare> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<Mäklare> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody]MäklareDto mäklareDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(mäklareDto.Email);
            if (existingUser != null)
            {
                return Conflict("En användare med den E-posten finns redan.");
            }
            try
            {
                Mäklare mäklare = new Mäklare()
                {
                    UserName = mäklareDto.Email,
                    Email = mäklareDto.Email,
                    Förnamn = mäklareDto.Förnamn,
                    Efternamn = mäklareDto.Efternamn
                };
                var result = await _userManager.CreateAsync(mäklare, mäklareDto.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRoleAsync(mäklare, ApiRoles.Mäklare);
                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(Register)}: {ex.Message}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponse>> Login([FromBody]LoginRequest loginDto)
        {
            var mäklare = await _userManager.FindByEmailAsync(loginDto.Email);
            var passwordValid = await _userManager.CheckPasswordAsync(mäklare, loginDto.Password);

            if (mäklare == null || passwordValid == false)
            {
                return Unauthorized();
            }
            try
            {
                // skapa jwt
                string tokenString = await GenerateToken(mäklare);

                var response = new LoginResponse
                {
                    Email = loginDto.Email,
                    Token = tokenString,
                    Id = mäklare.Id
                };

                return Accepted(response);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(Login)}", statusCode: 500);
            }
        }

        private async Task<string> GenerateToken(Mäklare mäklare)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(mäklare);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, mäklare.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, mäklare.Email),
                new Claim(CustomClaimTypes.Uid, mäklare.Id)
            }.Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
