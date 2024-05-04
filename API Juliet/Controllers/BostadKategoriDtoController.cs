using API_Juliet.Repositorys;
using API_Juliet.Repositorys.Contracts;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Juliet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BostadKategoriDtoController : ControllerBase
    {
        private readonly IBostadKategori _bostadKategoriRepository;

        public BostadKategoriDtoController(IBostadKategori bostadKategoriRepository)
        {
            _bostadKategoriRepository = bostadKategoriRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BostadKategoriDto>>> GetBostadKategorier()
        {
            var bostadKategorier = await _bostadKategoriRepository.GetAllBostadKategoriDtosAsync();

            return Ok(bostadKategorier);
        }
    }
}
