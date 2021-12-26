using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.VaccinationPlanAggregate;

public interface IVaccinationPlanRepository: IRepository<VaccinationPlan>
{
    Task<VaccinationPlan> GetAsync(Guid id);
    
    VaccinationPlan Add(VaccinationPlan plan);
    
    void Update(VaccinationPlan plan);
}
