using API_Juliet.Data;
using API_Juliet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MäklareController : ControllerBase
    {
        private readonly IMäklareRepository _mäklareRepository;

        public MäklareController(IMäklareRepository mäklareRepository)
        {
            _mäklareRepository = mäklareRepository ?? throw new ArgumentNullException(nameof(mäklareRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mäklare>>> GetMäklare()
        {
            var mäklare = await _mäklareRepository.GetAllAsync();
            return Ok(mäklare);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mäklare>> GetMäklare(int id)
        {
            var mäklare = await _mäklareRepository.GetByIdAsync(id);

            if (mäklare == null)
            {
                return NotFound();
            }

            return mäklare;
        }

        [HttpPost]
        public async Task<ActionResult<Mäklare>> CreateMäklare(Mäklare mäklare)
        {
            await _mäklareRepository.AddAsync(mäklare);

            return CreatedAtAction(nameof(GetMäklare), new { id = mäklare.Id }, mäklare);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMäklare(int id, Mäklare mäklare)
        {
            if (id != mäklare.Id)
            {
                return BadRequest();
            }

            try
            {
                await _mäklareRepository.UpdateAsync(mäklare);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMäklare(int id)
        {
            var mäklare = await _mäklareRepository.GetByIdAsync(id);
            if (mäklare == null)
            {
                return NotFound();
            }

            await _mäklareRepository.DeleteAsync(mäklare);

            return NoContent();
        }
    }
}
