using ExtractCssValuesToJson.Models;

namespace ExtractCssValuesToJson.Services;
public class HomeService: IHomeService {
    public List<Response> ExtractCssValuesToJson(Request req) {
        List<Response> responses = new List<Response>();

        if (req.Archives == null || req.Archives.Count == 0) {
            throw new Exception("Deve conter pelo menos um arquivo CSS!");
        }

        if (req.Archives.Count > 1000) {
            throw new Exception("Excedeu o limite de 500 arquivos!");
        }

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

        return responses;
    }

    public string[] ListNameFile(string directory) {
        string[] fileNames = Directory.GetFiles(directory)
                              .Select(filePath => Path.GetFileNameWithoutExtension(filePath))
                              .ToArray();

        return fileNames;
    }
}
