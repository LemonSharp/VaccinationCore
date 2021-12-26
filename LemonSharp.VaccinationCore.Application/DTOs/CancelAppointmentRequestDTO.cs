namespace LemonSharp.VaccinationCore.Application.DTOs;

public class CancelAppointmentRequestDTO
{
    public Guid UserId { get; set; }

    public Guid AppointmentRecordId { get; set; }
}
