using LemonSharp.VaccinationCore.Query;
using LemonSharp.VaccinationCore.Query.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationCore.API.Controllers;

[Route("api/[controller]/[action]")]
public class AppointmentController : Controller
{
    private readonly IAppointmentQueries _appointmentQueries;

    public AppointmentController(IAppointmentQueries appointmentQueries)
    {
        _appointmentQueries = appointmentQueries;
    }

    [HttpGet]
    public Task<AppointmentItemDTO[]> List([FromQuery] AppointmentListRequestDTO request)
    {
        return _appointmentQueries.GetAppointmentList(request);
    }
}
