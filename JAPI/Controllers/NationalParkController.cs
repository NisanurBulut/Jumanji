using AutoMapper;
using JAPI.Models.Dtos;
using JAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var objList = _npRepo.GetNationalParks();
            var objDtos = new List<NationalParkDto>();
            foreach (var item in objList)
            {
                objDtos.Add(_mapper.Map<NationalParkDto>(item));
            }
            return Ok(objDtos);
        }
        [HttpGet]
        public IActionResult GetNationalPark(int id)
        {
            var objList = _npRepo.GetNationalPark(id);
            return Ok(objList);
        }

    }
}
