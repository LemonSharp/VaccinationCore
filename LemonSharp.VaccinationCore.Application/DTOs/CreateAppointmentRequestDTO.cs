namespace LemonSharp.VaccinationCore.Application.DTOs;

public class CreateAppointmentRequestDTO
{
    public Guid UserId { get; set; }

    public Guid SiteId { get; set; }

    public string SiteName { get; set; }

    public double AddressLongitude { get; set; }

    public double AddressLatitude { get; set; }

    public string AddressName { get; set; }
    public DateTime AppointmentDate { get; set; }
}
