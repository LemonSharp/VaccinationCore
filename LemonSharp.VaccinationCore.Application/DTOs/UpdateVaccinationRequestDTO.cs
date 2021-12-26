namespace LemonSharp.VaccinationCore.Application.DTOs;

public class UpdateVaccinationRequestDTO
{
    public Guid PlanId { get; set; }

    public int SerialNumber { get; set; }
}
