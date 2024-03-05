using System.Reflection;
using Application.Interfaces;
using Application.Interfaces.Mapeamento;
using Application.MapingConfig;
using Infra.Data.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Produto.Repository.Context;
using Produto.Repository.Implementacoes;
using Produto.Repository.Interfaces;
using Produto.Services.Implementacoes;
using Produto.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapster();

builder.Services.AddDbContext<ProdutoDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

builder.Services.AddScoped<AppDbContext, ProdutoDbContext>();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IRepositoryProduto, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

ConfigurarMapeamento.Configure(Assembly.GetExecutingAssembly());

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
