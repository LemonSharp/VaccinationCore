using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonSharp.VaccinationCore.Infrastructure.EntityConfigurations;

public class VaccinationPlanEntityConfiguration : IEntityTypeConfiguration<VaccinationPlan>
{
    public void Configure(EntityTypeBuilder<VaccinationPlan> builder)
    {
        builder.ToTable("VaccinationPlans");

        builder.Ignore(x => x.DomainEvents);

        builder.HasKey(x => x.Id);
        
        builder.HasMany<VaccinationPlanItem>(x => x.VaccinationPlanItems)
            .WithOne()
            .HasForeignKey(x => x.PlanId);
    }
}
