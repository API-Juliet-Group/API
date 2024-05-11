using API_Juliet.Models;
using API_Juliet.Repositorys;
using API_Juliet.Repositorys.Contracts;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            bostad = await _bostadRepository.GetBostad(id);

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
            await _bostadRepository.DeleteBostadAsync(id);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BostadDto>> CreateBostad(BostadDto bostadDto)
        {

            try
            {
                var newBostad = await _bostadRepository.AddBostadDtoAsync(bostadDto);

                if (newBostad == null)
                {
                    return NoContent();
                }

                var newBostadDto = await _bostadRepository.GetBostad(newBostad.Id);

                if (newBostadDto == null)
                {
                    throw new Exception("Something went wrong when attempting to retrieve the added bostad");
                }


                return CreatedAtAction(nameof(GetBostad), new { id = newBostadDto.Id }, newBostadDto);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBostad(int id, BostadDto bostadDto)
        {
            if (id != bostadDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _bostadRepository.UpdateBostad(bostadDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
