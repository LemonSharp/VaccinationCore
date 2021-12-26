using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;

public class AppointmentRecord : Entity
{
    public Guid UserId { get; private set; }

    public Guid SiteId { get; private set; }

    public string SiteName { get; private set; }

    public double AddressLongitude { get; private set; }

    public double AddressLatitude { get; private set; }

    public string AddressName { get; private set; }
    public DateTime AppointmentDate { get; private set; }

    public AppointmentStatus Status { get; private set; }

    public AppointmentRecord()
    {
    }
    
    public AppointmentRecord(
        Guid sitId,
        string siteName,
        double addressLongitude,
        double addressLatitude,
        string addressName,
        DateTime appointmentDate)
    {
        SiteId = sitId;
        SiteName = siteName;
        AddressLongitude = addressLongitude;
        AddressLatitude = addressLatitude;
        AddressName = addressName;
        AppointmentDate = appointmentDate;
        Status = AppointmentStatus.Pending;
    }

    public void Accept()
    {
        Status = AppointmentStatus.Accepted;
    }

    public void Cancel()
    {
        Status = AppointmentStatus.Canceled;
    }
}
