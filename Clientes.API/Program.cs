using Clientes.Application.Commands.CreateCliente;
using Clientes.Application.Validators;
using Clientes.Core.Repositories;
using Clientes.Infrastructure;
using Clientes.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var configuration = builder.Configuration.GetConnectionString("ClientesCs");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddValidatorsFromAssemblyContaining<CreateClienteCommandValidator>(); 

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateClienteCommandValidator>());
//builder.Services.AddDbContext<ClientesDbContext>(x => x.UseInMemoryDatabase("ClientesDatabase"));
builder.Services.AddDbContext<ClientesDbContext>(options => options.UseSqlServer(configuration));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddMediatR(typeof(CreateClienteCommand));


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
