using System.Text.Json.Serialization;
using FechamentoPedido.Jobs;
using FechamentoPedido.Repository;
using FechamentoPedido.Repository.Implementacoes;
using FechamentoPedido.Repository.Interfaces;
using FechamentoPedido.Services.Implementacoes;
using FechamentoPedido.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FechamentoPedidoContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryProdutoCarinho, RepositoryProdutoCarinho>();
builder.Services.AddScoped<IRepositoryCarinho, RepositoryCarinho>();

builder.Services.AddScoped<IServiceProduto, ServicoProduto>();
builder.Services.AddScoped<IServiceCarinho, ServiceCarinho>();


#region Quartz

builder.Services.Configure<QuartzOptions>(options =>
{
    options.Scheduling.IgnoreDuplicates = true; // default: false
    options.Scheduling.OverWriteExistingData = true; // default: true
});


builder.Services.AddQuartz(q => {

    q.UseSimpleTypeLoader();
    q.UseInMemoryStore();
    q.UseDefaultThreadPool(tp =>
    {
        tp.MaxConcurrency = 10;
    });

    q.ScheduleJob<GerenciarProdutosCarinhoJob>(trigger => trigger
     .WithIdentity("GerenciamentoProdutos")
     .StartNow()
     .WithDailyTimeIntervalSchedule(x => x.WithInterval(10, IntervalUnit.Second))
     .WithDescription("Gerencia Adição e atualização de produtos")
 );
});

#endregion


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
