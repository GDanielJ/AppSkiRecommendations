using API.Helpers;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISkierRecommendationService _skierService;

        public RecommendationController(IMapper mapper, ISkierRecommendationService skierService)
        {
            _mapper = mapper;
            _skierService = skierService;
        }

        [HttpGet]
        public ActionResult<SkierToReturnDto> GetRecommendation([FromQuery] SkierParams skierParams)
        {
            var skierToReturn = _skierService.GetSkierWithRecommendations(skierParams.Age, skierParams.Height, skierParams.Discipline);

            if (skierToReturn.ValidLengthHeightDiscipline == false)
            {
                return BadRequest("Please enter a correct age, height and discipline");
            }

            var skierToReturnDto = _mapper.Map<Skier, SkierToReturnDto>(skierToReturn);

            return Ok(skierToReturnDto);
        }
    }
}