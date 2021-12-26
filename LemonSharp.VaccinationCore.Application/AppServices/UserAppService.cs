using LemonSharp.VaccinationCore.Application.DTOs;
using LemonSharp.VaccinationCore.Domain;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;

namespace LemonSharp.VaccinationCore.Application.AppServices;

public class UserAppService : IUserAppService
{
    private readonly IUserRepository _userRepository;

    public UserAppService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BusinessResult> CreateUserAsync(CreateUserRequestDTO userDto)
    {
        var user = new User(userDto.Name, userDto.Age, userDto.PhoneNumber);
        _userRepository.Add(user);
        await _userRepository.UnitOfWork.SaveEntitiesAsync();
        return new BusinessResult(BusinessCode.Success, "用户创建成功");
    }
}
