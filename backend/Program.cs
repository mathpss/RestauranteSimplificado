using backend.Context;
using backend.Middleware;
using backend.Models;
using backend.Services;
using backend.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RestauranteContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPostgreSQL")));

builder.Services.AddMemoryCache();

builder.Services.AddScoped<ICardapioService, CardapioService>();
builder.Services.AddScoped<IPedidoEntregaService, PedidoEntregaService>();
builder.Services.AddScoped<IPedidoRetiradaService, PedidoRetiradaService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
    {
        options.WithOrigins("http://localhost:3000");
        options.AllowAnyHeader();
        options.AllowAnyMethod();
    }
);

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
