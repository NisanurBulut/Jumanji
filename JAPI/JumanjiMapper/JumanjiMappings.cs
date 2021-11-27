using AutoMapper;
using JAPI.Models;
using JAPI.Models.Dtos;

namespace JAPI.JumanjiMapper
{
    public class JumanjiMappings : Profile
    {
        public JumanjiMappings()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
        }
    }
}
