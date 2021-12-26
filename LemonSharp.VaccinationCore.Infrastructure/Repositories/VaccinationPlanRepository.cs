using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.VaccinationPlanAggregate;
using LemonSharp.VaccinationCore.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace LemonSharp.VaccinationCore.Infrastructure.Repositories;

public class VaccinationPlanRepository : IVaccinationPlanRepository
{
    private readonly VaccinationCoreContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public VaccinationPlanRepository(VaccinationCoreContext context)
    {
        _context = context;
    }

    public Task<VaccinationPlan> GetAsync(Guid id)
    {
        return _context.VaccinationPlans
            .Include(x => x.VaccinationPlanItems)
            .SingleOrDefaultAsync(x => x.Id == id);
    }


    public VaccinationPlan Add(VaccinationPlan plan)
    {
        _context.VaccinationPlans.Add(plan);
        return plan;
    }

    public void Update(VaccinationPlan user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }
}
