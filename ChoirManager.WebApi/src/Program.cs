using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.WebApi.Database;
using ChoirManager.WebApi.Repositories;
using ChorManager.WebApi.Repositories;

namespace ChoirManager.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        // Configurations
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.Development.json");
        
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddDbContext<DatabaseContext>();
        builder.Services.AddChoirDependencies();

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

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();       
    }
}