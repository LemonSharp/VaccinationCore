using Dapr;
using LemonSharp.VaccinationCore.Application.AppServices;
using LemonSharp.VaccinationCore.Application.DTOs;
using LemonSharp.VaccinationCore.Query;
using LemonSharp.VaccinationCore.Query.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationCore.API.Controllers;

[Route("/api/[controller]/[action]")]
public class AppointmentController : Controller
{
    private readonly IAppointmentQueries _appointmentQueries;

    private readonly IAppointmentAppService _appointmentAppService;

    public AppointmentController(IAppointmentAppService appointmentAppService, IAppointmentQueries appointmentQueries)
    {
        _appointmentAppService = appointmentAppService;
        _appointmentQueries = appointmentQueries;
    }

    [HttpPost]
    [Topic("pubsub", "AppointmentCompletedEvent")]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequestDTO request)
    {
        var result = await _appointmentAppService.CreateAppointmentAsync(request);
        return Ok(result);
    }
    
    [HttpPost]
    [Topic("pubsub", "AppointmentCanceledEvent")]
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

    [HttpGet]
    public Task<AppointmentItemDTO[]> List([FromQuery] AppointmentListRequestDTO request)
    {
        return _appointmentQueries.GetAppointmentList(request);
    }
}
