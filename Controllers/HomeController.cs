using ExtractCssValuesToJson.Models;
using ExtractCssValuesToJson.Repositories;
using ExtractCssValuesToJson.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ExtractCssValuesToJson.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        private readonly ILogRequestRepository _logRequestRepository;
        private readonly IHttpContextAccessor _context;

        public HomeController(IHomeService homeService, ILogRequestRepository logRequestRepository, IHttpContextAccessor context) {
            _homeService = homeService;
            _logRequestRepository = logRequestRepository;
            _context = context;
        }

        [HttpPost]
        public IActionResult Index([FromForm] Request req)
        {
            LogRequest logRequest = new LogRequest();
            logRequest.FilesLengthRequest = req.Archives.Count;
            logRequest.ConfigRequest = JsonSerializer.Serialize(req.Configs);
            logRequest.IpClient = _context.HttpContext.Connection.RemoteIpAddress.ToString() ?? string.Empty;

            try {
                List<Response> response = _homeService.ExtractCssValuesToJson(req);
                logRequest.ContentResponse = JsonSerializer.Serialize(response);

                _logRequestRepository.AddLogRequestAsync(logRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logRequest.HttpResponse = HttpResponseEnum.BadRequest;
                logRequest.ContentResponse = ex.Message;

                _logRequestRepository.AddLogRequestAsync(logRequest);
                return BadRequest(ex.Message);
            }
        }
    }
}
