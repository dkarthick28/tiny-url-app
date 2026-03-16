using Microsoft.EntityFrameworkCore;
using TinyUrl.API.Helpers;
using TinyUrl.API.Middleware;
using TinyUrl.Repository.Interface;
using TinyUrl.Repository.Model;
using TinyUrl.Repository.Repositories;
using TinyUrl.Service.Interface;
using TinyUrl.Service.Services;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<TokenService>();
builder.Services.AddScoped<ITinyURLService, TinyURLService>();
builder.Services.AddScoped<ITinyURLRepository, TinyURLRepository>();
builder.Services.AddAutoMapper(typeof(TinyUrlAutoMapper));
builder.Services.AddSingleton<AzureBlobLogger>();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactLocal", policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors("AllowReactLocal");
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
