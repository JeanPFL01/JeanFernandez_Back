using AutoMapper;
using Business.Interface;
using Data.Interface;
using Data.Repository;
using Entity.DTO.Request;
using Entity.DTO.Response;
using Entity.Models;

namespace Business.Application
{
    public class HijoApplication : IHijoApplication
    {
        private readonly IHijoRepository _hijoRepository;
        private readonly IMapper _mapper;
        public HijoApplication(IHijoRepository hijoRepository, IMapper mapper)
        {
            _hijoRepository = hijoRepository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> AddOrUpdateHijo(AddOrUpdateHijoRequestDto hijo)
        {
            var response = new Response<bool>();
            try
            {
                var obj = _mapper.Map<Hijo>(hijo);
                var result = await _hijoRepository.AddOrUpdateHijo(obj);
                response.Data = result;
                response.Message = "El Hijo se " + (hijo.IdHijo > 0 ? "actualizó" : "agregó") + " correctamente";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteHijo(int IdHijo)
        {
            var response = new Response<bool>();
            try
            {
                var result = await _hijoRepository.DeleteHijo(IdHijo);
                response.Data = result;
                response.Message = "El Hijo se eliminó correctamente";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetHijoResponseDto>> GetHijoById(int IdHijo)
        {
            var response = new Response<GetHijoResponseDto>();
            try
            {
                var result = await _hijoRepository.GetHijoById(IdHijo);
                response.Data = _mapper.Map<GetHijoResponseDto>(result);
                response.Message = "";
            }
            catch (Exception ex)
            {
                response.Data = new GetHijoResponseDto();
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<GetListHijoResponseDto>>> GetHijosByIdPersonal(int IdPersonal)
        {
            var response = new Response<List<GetListHijoResponseDto>>();
            try
            {
                var result = await _hijoRepository.GetHijosByIdPersonal(IdPersonal);
                response.Data = _mapper.Map<List<GetListHijoResponseDto>>(result);
                response.Message = "";
            }
            catch (Exception ex)
            {
                response.Data = new List<GetListHijoResponseDto>();
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
