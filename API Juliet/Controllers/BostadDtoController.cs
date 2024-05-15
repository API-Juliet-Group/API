using API_Juliet.Constants;
using API_Juliet.Models;
using API_Juliet.Repositorys;
using API_Juliet.Repositorys.Contracts;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BostadDtoController : ControllerBase
    {
        private BostadDto bostad;
        IEnumerable<BostadDto> bostäder;

        private readonly IBostad _bostadRepository;
        public BostadDtoController(IBostad bostadRepository)
        {
            _bostadRepository = bostadRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BostadDto>> GetBostad(int id)
        {
            bostad = await _bostadRepository.GetBostadDtoByIdAsync(id);

            if (bostad == null)
            {
                return NotFound();
            }

            return bostad;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BostadDto>>> GetBostäder()
        {
            bostäder = await _bostadRepository.GetAllBostadDtosAsync();

            return Ok(bostäder);
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = ApiRoles.Mäklare)]
        public async Task<IActionResult> DeleteBostad(int id)
        {
            await _bostadRepository.DeleteDtoAsync(id);

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = ApiRoles.Mäklare)]
        public async Task<ActionResult<BostadDto>> CreateBostad(BostadDto bostadDto)
        {
            if (bostadDto == null)
            {
                return BadRequest("BostadDto is null");
            }

            try
            {
                await _bostadRepository.AddBostadDtoAsync(bostadDto);

                return CreatedAtAction(nameof(GetBostad), new { id = bostadDto.Id }, bostadDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }


}
