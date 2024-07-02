using ExtractCssValuesToJson.Services;
using Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddCors();
builder.Services.AddDbContext<SQLiteDbContext>();

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
