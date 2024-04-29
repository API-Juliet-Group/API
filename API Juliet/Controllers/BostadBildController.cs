using API_Juliet.Repositorys.Contracts;
using API_Juliet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BostadBildController : ControllerBase
    {
        private readonly IBostadBild _bostadBildRepository;

        public BostadBildController(IBostadBild bostadBildRepository)
        {
            _bostadBildRepository = bostadBildRepository;
        }

        [HttpPost]
        public async Task<ActionResult<BostadBild>> CreateBostadBild(BostadBild bostadBild)
        {
            await _bostadBildRepository.AddAsync(bostadBild);
            return CreatedAtAction(nameof(GetBostadBild), new { id = bostadBild.Id }, bostadBild);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BostadBild>> GetBostadBild(int id)
        {
            var bostadBild = await _bostadBildRepository.GetByIdAsync(id);

            if (bostadBild == null)
            {
                return NotFound();
            }

            return bostadBild;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BostadBild>>> GetBostadBilder()
        {
            var bostadsBilder = await _bostadBildRepository.GetAllAsync();

            return Ok(bostadsBilder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBostadBild(int id, BostadBild bostadBild)
        {
            if (id != bostadBild.Id)
            {
                return BadRequest();
            }

            try
            {
                await _bostadBildRepository.UpdateAsync(bostadBild);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBostadBild(int id)
        {
            var bostadBild = await _bostadBildRepository.GetByIdAsync(id);
            if (bostadBild == null)
            {
                return NotFound();
            }

            await _bostadBildRepository.DeleteAsync(bostadBild);

            return NoContent();
        }
    }
}
