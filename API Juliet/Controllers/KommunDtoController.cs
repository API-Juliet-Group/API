/*
  Author: Tobias Svensson
 */
using API_Juliet.Repositorys.Contracts;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KommunDtoController : ControllerBase
    {
        private readonly IKommun _kommunRepository;

        public KommunDtoController(IKommun kommunRepository)
        {
            _kommunRepository = kommunRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KommunDto>>> GetKommuner()
        {
            var kommuner = await _kommunRepository.GetAllKommunDtosAsync();

            return Ok(kommuner);
        }
    }
}
