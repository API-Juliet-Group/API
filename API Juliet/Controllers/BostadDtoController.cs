using API_Juliet.Repositorys.Contracts;
using BaseLibrary.DTO;
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
        public async Task<IActionResult> DeleteBostad(int id)
        {
            await _bostadRepository.DeleteDtoAsync(id);

            return NoContent();
        }
    }


}
