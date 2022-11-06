using Application.Pessoa.Command.AdicionarPessoa;
using Infrastructure.Contexto;
using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(AdicionarPessoaCommandHandler).GetTypeInfo().Assembly);

builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer("Data Source = LKDEV69; Initial Catalog = crudPessoaBackEnd; Integrated Security = True", b => b.MigrationsAssembly("crud-pessoa-backend")));

var app = builder.Build();

app.UseCors(delegate (CorsPolicyBuilder policyBuilder)
{
    policyBuilder
        .SetIsOriginAllowed((o) => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});

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
