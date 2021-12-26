using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.VaccinationPlanAggregate;
using LemonSharp.VaccinationCore.Domain.SeedWork;
using LemonSharp.VaccinationCore.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LemonSharp.VaccinationCore.Infrastructure;

public class VaccinationCoreContext : DbContext, IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<VaccinationPlan> VaccinationPlans { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlServer(
    //         "Server=tcp:lemon-sharp.database.windows.net,1433;Initial Catalog=reservation;Persist Security Info=False;User ID=lemon;Password=Test@123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;database=VaccinationCore");

    public VaccinationCoreContext(DbContextOptions<VaccinationCoreContext> options) : base(options)
    {
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Entity entity && entity.IsTransient())
            {
                entry.State = EntityState.Added;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);
        return true;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppointmentRecordEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VaccinationPlanEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VaccinationPlanItemEntityConfiguration());
        
    }
}
