namespace LemonSharp.VaccinationCore.Application.DTOs;

public class CancelAppointmentRequestDTO
{
    public long UserId { get; set; }

    public DateTime AppointmentDate { get; set; }
}
