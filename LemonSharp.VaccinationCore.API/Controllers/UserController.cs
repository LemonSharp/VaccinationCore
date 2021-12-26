using LemonSharp.VaccinationCore.Application.AppServices;
using LemonSharp.VaccinationCore.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationCore.API.Controllers;

[Route("/api/[controller]/[action]")]
public class UserController: Controller
{
    private readonly IUserAppService _userAppService;

    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody]CreateUserRequestDTO request)
    {
        var result = await _userAppService.CreateUserAsync(request);
        return Ok(result);
    }
}
