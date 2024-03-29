using Microsoft.EntityFrameworkCore;
using Npgsql.Lab;
using Npgsql.Lab.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<ApplicationDbContext>(c =>
        {
            c.UseNpgsql("Server=localhost:5433;Database=npgsql_lab;User Id=postgres;Password=postgres");
        }, ServiceLifetime.Singleton);
    })
    .Build();

host.Run();
