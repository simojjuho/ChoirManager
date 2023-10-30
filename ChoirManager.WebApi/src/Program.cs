using ChoirManager.WebApi.Database;
using ChoirManager.Business.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;
using WebShopBackend.Infrastructure.Database;


namespace ChoirManager.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        // Configurations
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.Development.json");
        var configuration = configBuilder.Build();
        
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddDbContext<DatabaseContext>();
        builder.Services.AddSingleton<IInterceptor>(_ => new TimeStampInterceptor());
        builder.Services.AddChoirDependencies();

        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.Configure<RouteOptions>(options => 
            options.LowercaseUrls = true
        );

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
    }
}