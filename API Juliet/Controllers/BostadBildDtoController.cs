using API_Juliet.Repositorys;
using API_Juliet.Repositorys.Contracts;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BostadBildDtoController : ControllerBase
    {
        private readonly IBostadBild _bostadBildRepository;

        public BostadBildDtoController(IBostadBild bostadBildRepository)
        {
            _bostadBildRepository = bostadBildRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BostadBildDto>>> GetBostadsBilder()
        {
            var bostadsBilder = await _bostadBildRepository.GetBostadsBilderDtosAsync();

            return Ok(bostadsBilder);
        }

        [HttpGet("{bostadId}")]
        public async Task<ActionResult<IEnumerable<BostadBildDto>>> GetBostadensBilder(int bostadId)
        {
            var bostadsBilder = await _bostadBildRepository.GetBostadensBilderDtosAsync(bostadId);

            return Ok(bostadsBilder);
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<IEnumerable<BostadBildDto>>> PostBostadsBilderDtosAsync(IEnumerable<BostadBildDto> bostadBilderDtos)
        {
            if (bostadBilderDtos == null)
            {
                return BadRequest("List of BostadBildDtos are null");
            }

            try
            {
                await _bostadBildRepository.AddBostadsBilderDtosAsync(bostadBilderDtos);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("single")]
        public async Task<ActionResult<BostadBildDto>> PostBostadBildDtosAsync(BostadBildDto bostadBild)
        {
            if (bostadBild == null)
            {
                return BadRequest("BostadBildDto was null");
            }

            try
            {
                await _bostadBildRepository.AddBostadBildAsync(bostadBild);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBostadsBild(int id)
        {
            await _bostadBildRepository.DeleteBostadsBild(id);

            return NoContent();
        }
    }
}
