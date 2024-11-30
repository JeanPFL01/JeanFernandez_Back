using AutoMapper;
using Entity.DTO.Request;
using Entity.DTO.Response;
using Entity.Models;

namespace Business.AutoMapper
{
    public class PersonalProfile : Profile
    {
        public PersonalProfile()
        {
            CreateMap<AddOrUpdatePersonalRequestDto, Personal>()
           .ReverseMap();
            CreateMap<Personal, GetPersonalResponseDto>()
           .ReverseMap();
            CreateMap<Personal, GetListPersonalResponseDto>()
               .ForMember(dest => dest.IdPersonal, opt => opt?.MapFrom(src => src.IdPersonal))
               .ForMember(dest => dest.FechaNac, opt => opt?.MapFrom(src => src.FechaNac.ToString("dd/MM/yyyy")))
               .ForMember(dest => dest.FechaIngreso, opt => opt?.MapFrom(src => src.FechaIngreso.ToString("dd/MM/yyyy")))
           .ReverseMap();
        }
    }
}
