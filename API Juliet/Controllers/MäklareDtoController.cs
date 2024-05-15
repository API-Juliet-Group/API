using API_Juliet.Constants;
using API_Juliet.Models;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Http;
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
    public class MäklareDtoController : ControllerBase
    {
        private readonly UserManager<Mäklare> mäklareManager;
        private readonly IConfiguration configuration;

        public MäklareDtoController(UserManager<Mäklare> mäklareManager, IConfiguration configuration)
        {
            this.mäklareManager = mäklareManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(MäklareDto mäklareDto)
        {
            try
            {
                Mäklare mäklare = new Mäklare()
                {
                    UserName = mäklareDto.Email,
                    Email = mäklareDto.Email,
                    Förnamn = mäklareDto.Förnamn,
                    Efternamn = mäklareDto.Efternamn
                };
                var result = await mäklareManager.CreateAsync(mäklare, mäklareDto.Password);
                //await userManager.AddClaimsAsync(mäklare,
                //    [
                //        new Claim(JwtRegisteredClaimNames.Sub, mäklare.UserName),
                //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //        new Claim(JwtRegisteredClaimNames.Email, mäklare.Email),
                //        new Claim(CustomClaimTypes.Uid, mäklare.Id)
                //    ]
                //);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await mäklareManager.AddToRoleAsync(mäklare, ApiRoles.Mäklare);
                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(Register)}: {ex.Message}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDto loginDto)
        {
            try
            {
                var mäklare = await mäklareManager.FindByEmailAsync(loginDto.Email);
                var passwordValid = await mäklareManager.CheckPasswordAsync(mäklare, loginDto.Password);

                if (mäklare == null || passwordValid == false)
                {
                    return Unauthorized(loginDto);
                }
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
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await mäklareManager.GetRolesAsync(mäklare);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            //var userClaims = await userManager.GetClaimsAsync(mäklare);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, mäklare.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, mäklare.Email),
                new Claim(CustomClaimTypes.Uid, mäklare.Id)
            }.Union(roleClaims);
            //var claims = new List<Claim>
            //{

            //}.Union(userClaims);


            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
