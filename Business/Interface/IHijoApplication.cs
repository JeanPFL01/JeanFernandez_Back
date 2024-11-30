using Entity.DTO.Request;
using Entity.DTO.Response;
using Entity.Models;

namespace Business.Interface
{
    public interface IHijoApplication
    {
        Task<Response<List<GetListHijoResponseDto>>> GetHijosByIdPersonal(int IdPersonal);
        Task<Response<GetHijoResponseDto>> GetHijoById(int IdHijo);
        Task<Response<bool>> AddOrUpdateHijo(AddOrUpdateHijoRequestDto hijo);
        Task<Response<bool>> DeleteHijo(int IdHijo);
    }
}
