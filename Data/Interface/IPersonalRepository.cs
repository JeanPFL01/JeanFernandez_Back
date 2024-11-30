using Entity.Models;

namespace Data.Interface
{
    public interface IPersonalRepository
    {
        Task<List<Personal>> GetPersonal();
        Task<Personal> GetPersonalById(int IdPersonal);
        Task<bool> AddOrUpdatePersonal(Personal personal);
        Task<bool> DeletePersonal(int IdPersonal);
    }
}
