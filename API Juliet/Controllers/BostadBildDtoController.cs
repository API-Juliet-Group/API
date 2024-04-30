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
    }
}
