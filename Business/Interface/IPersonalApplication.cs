using Entity.DTO.Request;
using Entity.DTO.Response;
using Entity.Models;

namespace Business.Interface
{
    public interface IPersonalApplication
    {
        Task<Response<List<GetListPersonalResponseDto>>> GetPersonal();
        Task<Response<GetPersonalResponseDto>> GetPersonalById(int IdPersonal);
        Task<Response<bool>> AddOrUpdatePersonal(AddOrUpdatePersonalRequestDto personal);
        Task<Response<bool>> DeletePersonal(int IdPersonal);
    }
}
