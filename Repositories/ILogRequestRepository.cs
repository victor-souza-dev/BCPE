using ExtractCssValuesToJson.Models;

namespace ExtractCssValuesToJson.Repositories; 
public interface ILogRequestRepository {
    Task AddLogRequestAsync(LogRequest logRequest);
}
