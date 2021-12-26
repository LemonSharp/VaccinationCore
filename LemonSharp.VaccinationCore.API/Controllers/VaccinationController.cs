using LemonSharp.VaccinationCore.Query;
using LemonSharp.VaccinationCore.Query.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationCore.API.Controllers;

[Route("api/[controller]/[action]")]
public class VaccinationController: Controller
{
    private readonly IVaccinationQueries _vaccinationQueries;

    public VaccinationController(IVaccinationQueries vaccinationQueries)
    {
        _vaccinationQueries = vaccinationQueries;
    }

    [HttpGet]
    public Task<VaccinationPlanDTO[]> Plans(Guid userId)
    {
        return _vaccinationQueries.GetVaccinationPlans(userId);
    }
    
    [HttpGet]
    public Task<VaccinationPlanItemDTO[]> PlanItems(Guid userId)
    {
        return _vaccinationQueries.GetVaccinationPlanItems(userId);
    }
}
