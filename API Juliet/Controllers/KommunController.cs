using API_Juliet.Data;
using BaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KommunController : ControllerBase
    {
        private readonly IKommun _kommunRepository;

        public KommunController(IKommun kommunRepository)
        {
            _kommunRepository = kommunRepository ?? throw new ArgumentNullException(nameof(kommunRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kommun>>> GetKommuner()
        {
            var kommuner = await _kommunRepository.GetAllAsync();
            return Ok(kommuner);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kommun>> GetKommun(int id)
        {
            var kommun = await _kommunRepository.GetByIdAsync(id);

            if (kommun == null)
            {
                return NotFound();
            }

            return kommun;
        }

        [HttpPost]
        public async Task<ActionResult<Kommun>> CreateKommun(Kommun kommun)
        {
            await _kommunRepository.AddAsync(kommun);

            return CreatedAtAction(nameof(GetKommun), new { id = kommun.Id }, kommun);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKommun(int id, Kommun kommun)
        {
            if (id != kommun.Id)
            {
                return BadRequest();
            }

            try
            {
                await _kommunRepository.UpdateAsync(kommun);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKommun(int id)
        {
            var kommun = await _kommunRepository.GetByIdAsync(id);
            if (kommun == null)
            {
                return NotFound();
            }

            await _kommunRepository.DeleteAsync(kommun);

            return NoContent();
        }
    }
}
