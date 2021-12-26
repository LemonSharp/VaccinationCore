using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.VaccinationPlanAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonSharp.VaccinationCore.Infrastructure.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.AppointmentRecords)
            .WithOne()
            .HasForeignKey(b => b.UserId);
        
        builder.HasOne(b => b.VaccinationPlan)
            .WithOne()
            .HasForeignKey<VaccinationPlan>(b => b.UserId);
    }
}
