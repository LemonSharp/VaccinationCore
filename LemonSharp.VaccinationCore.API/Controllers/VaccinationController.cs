using LemonSharp.VaccinationCore.Application.AppServices;
using LemonSharp.VaccinationCore.Application.DTOs;
using LemonSharp.VaccinationCore.Query;
using LemonSharp.VaccinationCore.Query.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationCore.API.Controllers;

[Route("api/[controller]/[action]")]
public class VaccinationController: Controller
{
    private readonly IVaccinationAppService _vaccinationService;
    private readonly IVaccinationQueries _vaccinationQueries;

    public VaccinationController(IVaccinationQueries vaccinationQueries, IVaccinationAppService vaccinationService)
    {
        _vaccinationQueries = vaccinationQueries;
        _vaccinationService = vaccinationService;
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

    [HttpPost]
    public async Task<IActionResult> CreateVaccinationPlan([FromBody]CreateVaccinationRequestDTO request)
    {
        return Ok(await _vaccinationService.CreateVaccinationPlanAsync(request)); //
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateVaccinationPlan([FromBody]UpdateVaccinationRequestDTO request)
    {
        return Ok(await _vaccinationService.UpdateVaccinationPlanAsync(request));
    }
}
