using AutoMapper;
using JAPI.Models;
using JAPI.Models.Dtos;
using JAPI.Models.DTOs;

namespace JAPI.JumanjiMapper
{
    public class JumanjiMappings : Profile
    {
        public JumanjiMappings()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
            CreateMap<Trail, TrailDto>().ReverseMap();
            CreateMap<Trail, TrailUpdateDto>().ReverseMap();
        }
    }
}
