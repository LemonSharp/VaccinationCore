namespace LemonSharp.VaccinationCore.Application.DTOs;

public class CreateVaccinationRequestDTO
{
    public Guid UserId { get; set; }

    public int TotalCount { get; set; }

    public int[] Internals { get; set; }
}
