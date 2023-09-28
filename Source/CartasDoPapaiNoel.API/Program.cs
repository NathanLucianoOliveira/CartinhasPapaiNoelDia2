using CartasDoPapaiNoel.Application.AutoMapper;
using CartasDoPapaiNoel.Application.Interfaces;
using CartasDoPapaiNoel.Application.Services;
using CartasDoPapaiNoel.Data.Repositories;
using CartasDoPapaiNoel.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DomainToApplication), typeof(ApplicationToDomain));

builder.Services.AddScoped<IObterTodosOsJogosRepository, ObterTodosOsJogosRepository>();
builder.Services.AddScoped<IObterTodosOsJogosService, ObterTodosOsJogosService>();

builder.Services.AddScoped<IRegistroJogoRepository, RegistroJogoRepository>();
builder.Services.AddScoped<IRegistroJogoService, RegistroJogoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();