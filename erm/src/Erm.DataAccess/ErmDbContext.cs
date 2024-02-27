using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace Erm.DataAccess;

public sealed class ErmDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<RiskProfile> RiskProfiles {get; set;}
    public DbSet<BusinessProcess> BusinessProcesses {get; set;}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RiskProfile>()
        .ToTable("risk_profile");
        
       modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

