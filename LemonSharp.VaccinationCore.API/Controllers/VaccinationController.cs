using LemonSharp.VaccinationCore.Application.AppServices;
using LemonSharp.VaccinationCore.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationCore.API.Controllers;

[Route("/api/[controller]/[action]")]
public class VaccinationController: Controller
{
    private readonly IVaccinationAppService _vaccinationService;

    public VaccinationController(IVaccinationAppService vaccinationService)
    {
        _vaccinationService = vaccinationService;
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
