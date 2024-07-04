using ExtractCssValuesToJson.Models;
using Infrastructure.Context;

namespace ExtractCssValuesToJson.Repositories; 
public class LogRequestRepository: ILogRequestRepository {
    private readonly SQLiteDbContext _context;

    public LogRequestRepository(SQLiteDbContext context)
    {
        _context = context;
    }

    public async Task AddLogRequestAsync(LogRequest logRequest) {
        try {
            await _context.LogRequest.AddAsync(logRequest);
            await _context.SaveChangesAsync();
        } catch {
            throw new Exception("Error adding log request");
        }
    }
}
