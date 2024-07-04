using ExtractCssValuesToJson.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class SQLiteDbContext : DbContext {
    public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<LogRequest> LogRequest { get; set; }
}
