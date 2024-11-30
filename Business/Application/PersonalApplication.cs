using AutoMapper;
using Business.Interface;
using Data.Interface;
using Entity.DTO.Request;
using Entity.DTO.Response;
using Entity.Models;

namespace Business.Application
{
    public class PersonalApplication : IPersonalApplication
    {
        private readonly IPersonalRepository _personalRepository; 
        private readonly IMapper _mapper;
        public PersonalApplication(IPersonalRepository personalRepository, IMapper mapper) 
        {
            _personalRepository = personalRepository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> AddOrUpdatePersonal(AddOrUpdatePersonalRequestDto personal)
        {
            var response = new Response<bool>();
            try
            {
                var obj = _mapper.Map<Personal>(personal);
                var result = await _personalRepository.AddOrUpdatePersonal(obj);
                response.Data = result;
                response.Message = "El Personal se " + (personal.IdPersonal > 0 ? "actualizó" : "agregó") +" correctamente";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeletePersonal(int IdPersonal)
        {
            var response = new Response<bool>();
            try
            {
                var result = await _personalRepository.DeletePersonal(IdPersonal);
                response.Data = result;
                response.Message = "El Personal se eliminó correctamente";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<GetListPersonalResponseDto>>> GetPersonal()
        {
            var response = new Response<List<GetListPersonalResponseDto>>();
            try
            {
                var result = await _personalRepository.GetPersonal();
                response.Data = _mapper.Map<List<GetListPersonalResponseDto>>(result);
                response.Message = "";
            }
            catch (Exception ex)
            {
                response.Data = new List<GetListPersonalResponseDto>();
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetPersonalResponseDto>> GetPersonalById(int IdPersonal)
        {
            var response = new Response<GetPersonalResponseDto>();
            try
            {
                var result = await _personalRepository.GetPersonalById(IdPersonal);
                response.Data = _mapper.Map<GetPersonalResponseDto>(result);
                response.Message = "";
            }
            catch (Exception ex)
            {
                response.Data = new GetPersonalResponseDto();
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
