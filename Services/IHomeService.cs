using ExtractCssValuesToJson.Models;

namespace ExtractCssValuesToJson.Services {
    public interface IHomeService {
        public List<Response> ExtractCssValuesToJson(Request req);
        public string[] ListNameFile(string directory);
    }
}
