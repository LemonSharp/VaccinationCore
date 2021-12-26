using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonSharp.VaccinationCore.Infrastructure.EntityConfigurations;

public class AppointmentRecordEntityConfiguration : IEntityTypeConfiguration<AppointmentRecord>
{
    public void Configure(EntityTypeBuilder<AppointmentRecord> builder)
    {
        builder.ToTable("AppointmentRecords");
        
        builder.Ignore(x => x.DomainEvents);
        
        builder.HasKey(x => x.Id);
    }
}
