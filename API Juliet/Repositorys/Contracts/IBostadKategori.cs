using BaseLibrary.DTO;

namespace API_Juliet.Repositorys.Contracts
{
    public interface IBostadKategori
    {
        Task<IEnumerable<BostadKategoriDto>> GetAllBostadKategoriDtosAsync();
    }
}