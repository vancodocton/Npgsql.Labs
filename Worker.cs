using Npgsql.Lab.Data;

namespace Npgsql.Lab;

public class Worker : BackgroundService
{
    private readonly ApplicationDbContext _dbContext;

    public Worker(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Fact
        DateTime from = new(2024, 02, 01, 0, 0, 0, DateTimeKind.Unspecified);
        DateTime to = new(2024, 02, 29, 0, 0, 0, DateTimeKind.Unspecified);

        var query1 = _dbContext.Demo(from, to);
        _ = query1.ToList();

        return Task.CompletedTask;
    }
}
