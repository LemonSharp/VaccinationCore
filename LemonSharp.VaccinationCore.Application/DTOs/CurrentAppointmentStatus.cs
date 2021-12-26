namespace LemonSharp.VaccinationCore.Application.DTOs;

public class CurrentAppointmentStatusResponseDTO
{
    public int SerialNumber { get; set; }

    public int NextIntervalDays { get; set; }

    public Guid SiteId { get; set; }
}
