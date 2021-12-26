using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.VaccinationPlanAggregate;

public class VaccinationPlan : Entity, IAggregateRoot
{
    public Guid UserId { get; private set; }

    public int TotalCount { get; private set; }

    private List<VaccinationPlanItem> _vaccinationPlanItems;

    public IReadOnlyCollection<VaccinationPlanItem> VaccinationPlanItems => _vaccinationPlanItems?.AsReadOnly();

    public VaccinationPlanStatus Status { get; private set; }

    public VaccinationPlan()
    {
    }

    public VaccinationPlan(Guid userId, int totalCount, int[] intervals)
    {
        UserId = userId;
        TotalCount = totalCount;
        _vaccinationPlanItems = new List<VaccinationPlanItem>();
        for (var serialNumber = 0; serialNumber < intervals.Length - 1; serialNumber++)
        {
            int intervalDays = 0;

            if (serialNumber > 0)
            {
                intervalDays = intervals[serialNumber - 1];
            }

            _vaccinationPlanItems.Add(new VaccinationPlanItem(Id, userId, intervalDays, serialNumber));
        }

        Status = VaccinationPlanStatus.Pending;
    }

    public void Vaccinate(int serialNumber)
    {
        var planItem = _vaccinationPlanItems
            .Single(x => x.SerialNumber == serialNumber);

        planItem.Complete();

        var allDone = _vaccinationPlanItems.All(x => x.IsDone());
        if (allDone)
        {
            Status = VaccinationPlanStatus.Done;
        }
    }

    public VaccinationPlanItem NextPlan()
    {
        var nextPlanItem = _vaccinationPlanItems
            .OrderBy(x => x.SerialNumber)
            .FirstOrDefault(x => x.Status == VaccinationPlanItemStatus.Pending);

        return nextPlanItem;
    }

    public bool IsDone() => Status == VaccinationPlanStatus.Done;
}
