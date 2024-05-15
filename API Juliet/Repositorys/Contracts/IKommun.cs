using API_Juliet.Models;
using BaseLibrary.DTO;

namespace API_Juliet.Repositorys.Contracts
{
    public interface IKommun
    {
        Task<IEnumerable<KommunDto>> GetAllKommunDtosAsync();
    }
}
