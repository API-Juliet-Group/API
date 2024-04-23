using API_Juliet.Data;
using BaseLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BostadController : ControllerBase
    {
        private Bostad bostad;
        IEnumerable<Bostad> bostäder;

        private readonly IBostad _bostadRepository;
        public BostadController(IBostad bostadRepository)
        {
            _bostadRepository = bostadRepository;
        }


        [HttpPost]
        public async Task<ActionResult<Bostad>> CreateBostad(Bostad bostad)
        {
            await _bostadRepository.AddAsync(bostad);
            return CreatedAtAction(nameof(GetBostad), new { id = bostad.Id }, bostad);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Bostad>> GetBostad(int id)
        {
            bostad = await _bostadRepository.GetByIdAsync(id);

            if (bostad == null)
            {
                return NotFound();
            }

            return bostad;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bostad>>> GetBostäder()
        {
            bostäder = await _bostadRepository.GetAllAsync();

            return Ok(bostäder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBostad(int id, Bostad bostad)
        {
            if (id != bostad.Id)
            {
                return BadRequest();
            }

            try
            {
                await _bostadRepository.UpdateAsync(bostad);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBostad(int id)
        {
            bostad = await _bostadRepository.GetByIdAsync(id);
            if (bostad == null)
            {
                return NotFound();
            }

            await _bostadRepository.DeleteAsync(bostad);

            return NoContent();
        }
    }
}
