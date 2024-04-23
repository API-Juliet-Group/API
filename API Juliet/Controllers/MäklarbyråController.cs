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
    public class MäklarbyråController : ControllerBase
    {
        private readonly IMäklarbyrå _mäklarbyråRepository;

        public MäklarbyråController(IMäklarbyrå mäklarbyråRepository)
        {
            _mäklarbyråRepository = mäklarbyråRepository ?? throw new ArgumentNullException(nameof(mäklarbyråRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mäklarbyrå>>> GetMäklarbyrå()
        {
            var mäklarbyrå = await _mäklarbyråRepository.GetAllAsync();
            return Ok(mäklarbyrå);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mäklarbyrå>> GetMäklarbyrå(int id)
        {
            var mäklarbyrå = await _mäklarbyråRepository.GetByIdAsync(id);

            if (mäklarbyrå == null)
            {
                return NotFound();
            }

            return mäklarbyrå;
        }

        [HttpPost]
        public async Task<ActionResult<Mäklarbyrå>> CreateMäklarbyrå(Mäklarbyrå mäklarbyrå)
        {
            await _mäklarbyråRepository.AddAsync(mäklarbyrå);

            return CreatedAtAction(nameof(GetMäklarbyrå), new { id = mäklarbyrå.Id }, mäklarbyrå);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMäklarbyrå(int id, Mäklarbyrå mäklarbyrå)
        {
            if (id != mäklarbyrå.Id)
            {
                return BadRequest();
            }

            try
            {
                await _mäklarbyråRepository.UpdateAsync(mäklarbyrå);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMäklarbyrå(int id)
        {
            var mäklarbyrå = await _mäklarbyråRepository.GetByIdAsync(id);
            if (mäklarbyrå == null)
            {
                return NotFound();
            }

            await _mäklarbyråRepository.DeleteAsync(mäklarbyrå);

            return NoContent();
        }
    }
}
