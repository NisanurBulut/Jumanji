using AutoMapper;
using JAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace JAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class NationalParkController : ControllerBase
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;
        public NationalParkController(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }
    }
}
