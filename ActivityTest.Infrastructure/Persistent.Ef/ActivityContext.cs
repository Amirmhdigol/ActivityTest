using ActivityTest.Domain.ActivityTypeAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Infrastructure.Persistent.Ef;
public class ActivityContext : DbContext
{
    public ActivityContext(DbContextOptions<ActivityContext> options) : base(options)
    {

    }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<ActivityTypeLog> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActivityContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}