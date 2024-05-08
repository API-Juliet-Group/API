using API_Juliet.Constants;
using API_Juliet.Models;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MäklareDtoController : ControllerBase
    {
        private readonly UserManager<Mäklare> userManager;

        public MäklareDtoController(UserManager<Mäklare> userManager)
        {
            this.userManager = userManager;
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
                var result = await userManager.CreateAsync(mäklare, mäklareDto.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await userManager.AddToRoleAsync(mäklare, ApiRoles.Mäklare);
                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(Register)}: {ex.Message}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var mäklare = await userManager.FindByEmailAsync(loginDto.Email);
                var passwordValid = await userManager.CheckPasswordAsync(mäklare, loginDto.Password);

                if (mäklare == null || passwordValid == false)
                {
                    return NotFound();
                }
                // skapa jwt

                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
