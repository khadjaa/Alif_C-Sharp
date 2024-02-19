using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace Erm.DataAccess;

public sealed class ErmDbContext : DbContext
{
    private const string ConnectionString = "server=localhost;integrated security=True; database=alifDb;TrustServerCertificate=true;";
    public DbSet<RiskProfile> RiskProfiles {get; set;}
    public DbSet<BusinessProcess> BusinessProcesses {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RiskProfile>()
        .ToTable("risk_profile");
        
       modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

