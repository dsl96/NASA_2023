using API.services;
using API.services.implementation;
using DATA_CLASSES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssController : ControllerBase
    {

        private readonly IissDataService _issDataService ;

        public IssController(IissDataService issDataService)
        {
                _issDataService = issDataService ;
        }


        [HttpGet("Location")]
        public async Task<ActionResult<AstroidResponse>> GetIssLocation()
        {
 
            var response =  await _issDataService.GetIssLocation();

            if (response == null)
            {
                return  BadRequest(new { message = "An error occurred." });
            }

            return Ok(response);
        }


    }
}
