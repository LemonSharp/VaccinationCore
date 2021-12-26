using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;

public class RecommendedAppointment : ValueObject
{
    public int SerialNumber { get; private set; }

    public int NextIntervalDays { get; private set; }
    
    public Guid SiteId { get; private set; }

    public RecommendedAppointment(
        int serialNumber,
        int nextIntervalDays,
        Guid siteId)
    {
        NextIntervalDays = nextIntervalDays;
        SerialNumber = serialNumber;
        SiteId = siteId;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SerialNumber;
        yield return NextIntervalDays;
        yield return SiteId;
    }
}
