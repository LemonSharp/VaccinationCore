namespace LemonSharp.VaccinationCore.Query.DTOs;

public class AppointmentListRequestDTO
{
    public Guid? UserId { get; set; }
    public int? Status { get; set; }
}
