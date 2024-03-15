using Middleware;
using Infra.IOC;
using System.Reflection;
using Infra.Data.Context;
using Mapster;
using Cliente.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Cliente.Repository.Interfaces;
using Cliente.Repository.Implementacoes;
using Cliente.Services.Interfaces;
using Cliente.Services.Services;
using Cliente.DTO.Login;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtConfigure = builder.Configuration.GetSection("Jwt").Get<JwtConfiguration>();

builder.Services.AddSingleton(jwtConfigure);


builder.Services.AddMapster();

builder.Services.AddDbContext<ClienteDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

builder.Services.AddScoped<AppDbContext, ClienteDbContext>();

builder.Services.RegistrarValidadores(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IServiceToken, ServiceToken>();

builder.Services
    .AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseMiddleware<ErrorMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
