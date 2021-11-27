using AutoMapper;
using JAPI.Models;
using JAPI.Models.Dtos;
using JAPI.Models.DTOs;
using JAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JAPI.Controllers
{
    [Route("api/Trails")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TrailController : ControllerBase
    {
        private ITrailRepository _trRepo;
        private readonly IMapper _mapper;
        public TrailController(ITrailRepository npRepo, IMapper mapper)
        {
            _trRepo = npRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TrailDto>))]
        public IActionResult GetTrails()
        {
            var objList = _trRepo.GetTrails();
            var objDtos = new List<TrailDto>();
            foreach (var item in objList)
            {
                objDtos.Add(_mapper.Map<TrailDto>(item));
            }
            return Ok(objDtos);
        }
        [HttpGet("{id:int}", Name = "GetTrail")]
        [ProducesResponseType(200, Type = typeof(TrailDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetTrail(int id)
        {
            var obj = _trRepo.GetTrail(id);
            if (obj == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TrailDto>(obj));
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(TrailDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateTrail([FromBody] TrailUpsertDto trailDto)
        {
            if (trailDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_trRepo.TrailExists(trailDto.Name))
            {
                ModelState.AddModelError("", "Trail Exists!");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var trailObj = _mapper.Map<Trail>(trailDto);
            if (!_trRepo.CreateTrail(trailObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {trailObj.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetTrail", new { id = trailObj.Id }, trailObj);
        }
        [HttpPatch("{id:int}", Name = "UpdateTrail")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTrail(int id, [FromBody] TrailUpsertDto trailDto)
        {
            if (trailDto == null || id!=trailDto.Id)
            {
                return BadRequest(ModelState);
            }
            var trailObj = _mapper.Map<Trail>(trailDto);
            if (!_trRepo.UpdateTrail(trailObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {trailObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "DeleteTrail")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTrail(int id)
        {
            if (!_trRepo.TrailExists(id))
            {
               return NotFound();
            }
            var trailObj = _trRepo.GetTrail(id);
            if (!_trRepo.DeleteTrail(trailObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {trailObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
