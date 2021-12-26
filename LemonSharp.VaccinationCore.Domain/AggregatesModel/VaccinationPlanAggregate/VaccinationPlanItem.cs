using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.VaccinationPlanAggregate;

public class VaccinationPlanItem : Entity
{
    public Guid PlanId { get; private set; }
    public Guid UserId { get; private set; }
    public VaccinationPlanItemStatus Status { get; private set; }
    public int IntervalDays { get; private set; }
    public int SerialNumber { get; private set; }

    public VaccinationPlanItem(Guid planId, Guid userId, int intervalDays, int serialNumber)
    {
        PlanId = planId;
        UserId = userId;
        IntervalDays = intervalDays;
        SerialNumber = serialNumber;
        Status = VaccinationPlanItemStatus.Pending;
    }

    public bool IsDone() => Status == VaccinationPlanItemStatus.Done;

    public void Complete()
    {
        Status = VaccinationPlanItemStatus.Done;
    }
}
