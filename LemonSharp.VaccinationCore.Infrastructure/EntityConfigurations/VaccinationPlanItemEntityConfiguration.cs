using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonSharp.VaccinationCore.Infrastructure.EntityConfigurations;

public class VaccinationPlanItemEntityConfiguration : IEntityTypeConfiguration<VaccinationPlanItem>
{
    public void Configure(EntityTypeBuilder<VaccinationPlanItem> builder)
    { 
        builder.ToTable("VaccinationPlanItems");
        
        builder.Ignore(x => x.DomainEvents);
        
        builder.HasKey(x => x.Id);
    }
}
