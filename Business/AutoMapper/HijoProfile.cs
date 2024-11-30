using AutoMapper;
using Entity.DTO.Request;
using Entity.DTO.Response;
using Entity.Models;

namespace Business.AutoMapper
{
    public class HijoProfile : Profile
    {
        public HijoProfile()
        {
            CreateMap<AddOrUpdateHijoRequestDto, Hijo>()
           .ReverseMap();
            CreateMap<Hijo, GetHijoResponseDto>()
           .ReverseMap();
            CreateMap<Hijo, GetListHijoResponseDto>()
               .ForMember(dest => dest.IdHijo, opt => opt?.MapFrom(src => src.IdHijo))
               .ForMember(dest => dest.IdPersonal, opt => opt?.MapFrom(src => src.IdPersonal))
               .ForMember(dest => dest.FechaNac, opt => opt?.MapFrom(src => src.FechaNac.ToString("dd/MM/yyyy")))
           .ReverseMap();
        }
    }
}
