namespace LemonSharp.VaccinationCore.Query.DTOs;

public class AppointmentItemDTO
{
    public Guid UserId { get; set; }

    public Guid SiteId { get; set; }

    public string SiteName { get; set; } = string.Empty;

    public double AddressLongitude { get; set; }

    public double AddressLatitude { get; set; }

    public string AddressName { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }

    public int Status { get; set; }
}
