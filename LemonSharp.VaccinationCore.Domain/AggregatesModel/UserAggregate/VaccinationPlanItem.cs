using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;

public class VaccinationPlanItem : Entity
{
    public Guid PlanId { get; private set; }
    public VaccinationPlanItemStatus Status { get; private set; }
    public int IntervalDays { get; private set; }
    public int SerialNumber { get; private set; }
    
    public void Complete()
    {
        Status = VaccinationPlanItemStatus.Done;
    }
}
