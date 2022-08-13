using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Repositories.Despesas;
using Challenge_Backend_Financas.Repositories.Interfaces.Despesas;
using Challenge_Backend_Financas.Repositories.Interfaces.Receitas;
using Challenge_Backend_Financas.Repositories.Receitas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Contexto>(x => x.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.Parse("8.0.28")
    ));

builder.Services.AddScoped<IReceitasRepository, ReceitasRepository>();
builder.Services.AddScoped<IDespesasRepository, DespesasRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
