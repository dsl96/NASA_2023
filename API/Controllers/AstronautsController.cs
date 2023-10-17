using API.services;
using API.services.implementation;
using DATA_CLASSES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautsController : ControllerBase
    {

        private readonly IAstronautsService _astonutsService;
        public AstronautsController(IAstronautsService astonutsService)
        {
            _astonutsService = astonutsService;
        }

        [HttpGet("getList")]
        public async  Task<ActionResult<IEnumerable<AstronautResponse>>> GetAstronauts([FromQuery] AstronautFilter filter)
        {

            if(!ModelState.IsValid)
            {
               return BadRequest(ModelState);
            }

            var astronauts = await _astonutsService.GetAstronauts(filter);
            return Ok(astronauts);  
        }


              }
}

