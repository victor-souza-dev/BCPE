using ExtractCssValuesToJson.Models;
using ExtractCssValuesToJson.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ExtractCssValuesToJson.Services;
public class HomeService: IHomeService {
    private readonly ILogRequestRepository _logRequestRepository;
    private readonly IHttpContextAccessor _context;

    public HomeService(ILogRequestRepository logRequestRepository, IHttpContextAccessor context) {
        _logRequestRepository = logRequestRepository;
        _context = context;
    }

    public List<Response> ExtractCssValuesToJson(Request req) {
        LogRequest logRequest = new LogRequest();
        logRequest.FilesLengthRequest = req.Archives.Count;
        logRequest.ConfigRequest = JsonSerializer.Serialize(req.Configs);
        logRequest.IpClient = _context.HttpContext.Connection.RemoteIpAddress.ToString() ?? string.Empty;

        List<Response> responses = new List<Response>();

        try {
            foreach (var archive in req.Archives) {
                using (var memoryStream = new MemoryStream()) {
                    archive.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();
                    string fileContent = System.Text.Encoding.UTF8.GetString(fileBytes);
                    string fileName = Path.GetFileNameWithoutExtension(archive.FileName).Replace(".min", "");

                    ExtractProperty extractProperty = new ExtractProperty(fileName, fileContent, req.Configs);
                    Dictionary<string, string> properties = extractProperty.ExtractProperties();

                    responses.Add(new Response { Name = fileName, Values = properties });
                }
            }

            logRequest.ContentResponse = JsonSerializer.Serialize(responses);
            _logRequestRepository.AddLogRequestAsync(logRequest);

            return responses;
        } catch (Exception ex) {
            logRequest.ContentResponse = JsonSerializer.Serialize(ex.Message);
            logRequest.HttpResponse = HttpResponseEnum.BadRequest;
            _logRequestRepository.AddLogRequestAsync(logRequest);

            throw new BadHttpRequestException(ex.Message);
        }
    }

    public string[] ListNameFile(string directory) {
        string[] fileNames = Directory.GetFiles(directory)
                              .Select(filePath => Path.GetFileNameWithoutExtension(filePath))
                              .ToArray();

        return fileNames;
    }
}
