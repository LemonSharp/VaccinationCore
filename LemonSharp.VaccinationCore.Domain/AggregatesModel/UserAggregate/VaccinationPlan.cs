using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;

public class VaccinationPlan : Entity
{
    public Guid UserId { get; private set; }
    
    private List<VaccinationPlanItem> _vaccinationPlanItems;
    
    public IReadOnlyCollection<VaccinationPlanItem> VaccinationPlanItems => _vaccinationPlanItems?.AsReadOnly();

    public VaccinationPlanStatus Status { get; private set; }

    public VaccinationPlanItem NextPlan()
    {
        var nextPlanItem = _vaccinationPlanItems
            .OrderBy(x => x.SerialNumber)
            .First(x => x.Status == VaccinationPlanItemStatus.Pending);

        // TODO: handle if there is no next plan item

        return nextPlanItem;
    }
}
