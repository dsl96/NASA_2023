using API.services;
using DATA_CLASSES;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpaceController : ControllerBase
    {

        private readonly ILogger<SpaceController> _logger;
        private readonly INasaService _nasaService;



        public SpaceController(ILogger<SpaceController> logger, INasaService nasaService)
        {
            _logger = logger;
            _nasaService = nasaService;
        }

        [HttpGet("doron")]
        public async Task<ActionResult<NasaDailyImageResponse>> Get(DateTime? dateTime = null)
        {
            return await _nasaService.GetDailyImage(dateTime);
        }


        [HttpGet("AstroidResponseModel")]
        public async Task<AstroidResponse> GetAstroidList(DateTime startDate, DateTime endDate)
        {

            var respons =  await _nasaService.GetAastroidList(startDate, endDate);
            return respons;
        }
    }
}