/*
 * Author: Tobias Svensson
 * Edited for identity: Johan Ahlqvist
 */

using API_Juliet.Repositorys.Contracts;
using API_Juliet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Juliet.Constants;
using Microsoft.AspNetCore.Authorization;
using BaseLibrary.DTO;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MäklareController : ControllerBase
    {
        private readonly IMäklare _mäklareRepository;

        public MäklareController(IMäklare mäklareRepository)
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
        public async Task<ActionResult<MäklareDto>> GetMäklare(string id)
        {
            var mäklare = await _mäklareRepository.GetByIdAsync(id);

            if (mäklare == null)
            {
                return NotFound();
            }
            MäklareDto mäklareDto = new MäklareDto()
            {
                Förnamn = mäklare.Förnamn,
                Efternamn = mäklare.Efternamn,
                BildURL = mäklare.BildURL,
                MäklarbyråId = mäklare.MäklarbyråId
            };

            return mäklareDto;
        }

        [HttpPost]
        public async Task<ActionResult<Mäklare>> CreateMäklare(Mäklare mäklare)
        {
            await _mäklareRepository.AddAsync(mäklare);

            return CreatedAtAction(nameof(GetMäklare), new { id = mäklare.Id }, mäklare);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ApiRoles.Mäklare)]
        public async Task<IActionResult> UpdateMäklare(string id, MäklareDto mäklareDto)
        {
            if (mäklareDto == null)
            {
                return BadRequest("Mäklare data is required.");
            }

            var mäklare = await _mäklareRepository.GetByIdAsync(id);

            if (mäklare == null)
            {
                return NotFound();
            }
            mäklare.Förnamn = mäklareDto.Förnamn;
            mäklare.Efternamn = mäklareDto.Efternamn;
            mäklare.BildURL = mäklareDto.BildURL;
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
        [Authorize(Roles = ApiRoles.SuperAdmin)]
        public async Task<IActionResult> DeleteMäklare(string id)
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
