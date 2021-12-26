using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;

public  class User : Entity, IAggregateRoot
{
    public string Name { get; private set; }

    public int Age { get; private set; }

    public string PhoneNumber { get; private set; }

    public VaccinationPlan VaccinationPlan { get; private set; }

    private List<AppointmentRecord> _appointmentRecords;

    public IReadOnlyCollection<AppointmentRecord> AppointmentRecords => _appointmentRecords?.AsReadOnly();

    public User(string name, int age, string phoneNumber)
    {
        Name = name;
        Age = age;
        PhoneNumber = phoneNumber;
        _appointmentRecords = new List<AppointmentRecord>();
    }

    public void CreateAppointment(
        Guid sitId,
        string siteName, double addressLongitude,
        double addressLatitude, string addressName,
        DateTime appointmentDate)
    {
        _appointmentRecords.Add(new AppointmentRecord(
            sitId,
            siteName, addressLongitude, addressLatitude,
            addressName, appointmentDate));
    }


    public RecommendedAppointment NextRecommendedAppointment()
    {
        if (VaccinationPlan == null)
        {
            return null;
        }

        var nextPlan = VaccinationPlan.NextPlan();

        var lastAppointment =
            _appointmentRecords.Where(x => x.Status == AppointmentStatus.Accepted)
                .OrderByDescending(x => x.AppointmentDate)
                .FirstOrDefault();

        return new RecommendedAppointment(
            nextPlan.SerialNumber,
            nextPlan.IntervalDays,
            lastAppointment.SiteId);
    }
}
