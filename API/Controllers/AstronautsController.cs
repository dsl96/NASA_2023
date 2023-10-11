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

        private readonly IAstonutsService _astonutsService;
        public AstronautsController(IAstonutsService astonutsService)
        {
            _astonutsService = astonutsService;
        }

        [HttpGet("getList")]
        public async  Task<ActionResult<IEnumerable<AstronautResponse>>> GetAstronauts(int skip=0, int take=10)
        {
            var astronauts = await _astonutsService.GetAstronauts(skip:skip, take:take);
            return Ok(astronauts);  
        }


              }
}

