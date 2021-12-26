using LemonSharp.VaccinationCore.Query.DTOs;

namespace LemonSharp.VaccinationCore.Query;

public interface IVaccinationQueries
{
    Task<VaccinationPlanItemDTO[]> GetVaccinationPlanItems(Guid userId);
    Task<VaccinationPlanDTO[]> GetVaccinationPlans(Guid userId);
}
