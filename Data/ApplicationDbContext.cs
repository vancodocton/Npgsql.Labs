using Microsoft.EntityFrameworkCore;

namespace Npgsql.Lab.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public IQueryable<Terminal> Demo(DateTime in_from_dt, DateTime in_to_dt)
    {
        return FromExpression(() => Demo(in_from_dt, in_to_dt));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Terminal>();

        var method = typeof(ApplicationDbContext).GetMethod(nameof(Demo),
            new[]
            {
                typeof(DateTime),
                typeof(DateTime),
            }) ?? throw new InvalidOperationException();

        modelBuilder.HasDbFunction(method, builder =>
        {
            builder.HasParameter("in_from_dt")
                .HasStoreType("timestamp without time zone");
            builder.HasParameter("in_to_dt")
                .HasStoreType("timestamp without time zone");
        });
    }
}
