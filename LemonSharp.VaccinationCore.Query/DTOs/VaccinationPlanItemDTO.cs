namespace LemonSharp.VaccinationCore.Query.DTOs;

public class VaccinationPlanDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Status { get; set; }
    public int TotalCount { get; set; }
}

public class VaccinationPlanItemDTO
{
    public Guid Id { get; set; }
    public Guid PlanId { get; set; }
    public Guid UserId { get; set; }
    public int Status { get; set; }
    public int IntervalDays { get; set; }
    public int SerialNumber { get; set; }
}
