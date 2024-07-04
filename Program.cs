using ExtractCssValuesToJson.Middlewares;
using ExtractCssValuesToJson.Repositories;
using ExtractCssValuesToJson.Services;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cors = builder.Configuration.GetSection("Cors");

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy
            .WithOrigins("http://localhost:5173", "https://localhost:5173", "http://localhost:6011", "https://localhost:6011")
            .WithMethods("POST");
    });
});

builder.Services.AddDbContext<SQLiteDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<ILogRequestRepository, LogRequestRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseMiddleware<ErrorMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
