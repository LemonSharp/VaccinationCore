using LemonSharp.VaccinationCore.Application.AppServices;
using LemonSharp.VaccinationCore.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationCore.API.Controllers;

[Route("/api/[controller]/[action]")]
public class AppointmentController : Controller
{
    private readonly IAppointmentAppService _appointmentAppService;

    public AppointmentController(IAppointmentAppService appointmentAppService)
    {
        _appointmentAppService = appointmentAppService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequestDTO request)
    {
        var result = await _appointmentAppService.CreateAppointmentAsync(request);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CancelAppointment([FromBody] CancelAppointmentRequestDTO request)
    {
        var result = await _appointmentAppService.CancelAppointmentAsync(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> CurrentAppointmentStatus([FromQuery] Guid userId)
    {
        var result = await _appointmentAppService.GetCurrentAppointmentStatusAsync(userId);
        return Ok(result);
    }
}
