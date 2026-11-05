using Escola.Api.Controllers;
using Escola.Contexts;
using Escola.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//configurando os serviços da aplicação
builder.Services.AddScoped<AlunoService>();

var connstring = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContext<EscolaDbContext>(o => o.UseNpgsql(connstring));

var app = builder.Build();

//PIPELINES
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();

//var controller = new AlunoController(new AlunoService(new EscolaDbContext(null)));
// IOC - Inversion of Control (Inversão de Controle)
//var controller2 = app.Services.GetService<AlunoController>();