using ExtractCssValuesToJson.Repositories;
using ExtractCssValuesToJson.Services;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddDbContext<SQLiteDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// #region Service and Repository Configurations
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<ILogRequestRepository, LogRequestRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// #endregion

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => {
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
