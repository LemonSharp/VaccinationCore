using LemonSharp.VaccinationCore.Application.DTOs;

namespace LemonSharp.VaccinationCore.Application.AppServices;

public interface IUserAppService
{
    Task<BusinessResult> CreateUserAsync(CreateUserRequestDTO userDto); 
}
