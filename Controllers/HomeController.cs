using ExtractCssValuesToJson.Models;
using ExtractCssValuesToJson.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExtractCssValuesToJson.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpPost]
        public IActionResult Index([FromForm] Request req) {
            try {
                List<Response> response = _homeService.ExtractCssValuesToJson(req);
                return Ok(response);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
