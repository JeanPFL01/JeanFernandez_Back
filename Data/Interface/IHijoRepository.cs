using Entity.Models;

namespace Data.Interface
{
    public interface IHijoRepository
    {
        Task<List<Hijo>> GetHijosByIdPersonal(int IdPersonal);
        Task<Hijo> GetHijoById(int IdHijo);
        Task<bool> AddOrUpdateHijo(Hijo hijo);
        Task<bool> DeleteHijo(int IdHijo);
    }
}
