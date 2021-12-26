using LemonSharp.VaccinationCore.Application.DTOs;
using LemonSharp.VaccinationCore.Domain;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;

namespace LemonSharp.VaccinationCore.Application.AppServices;

public class AppointmentAppService : IAppointmentAppService
{
    private readonly IUserRepository _userRepository;

    public AppointmentAppService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BusinessResult> CreateAppointmentAsync(CreateAppointmentRequestDTO request)
    {
        var user = await _userRepository.GetAsync(request.UserId);

        user.CreateAppointment(request.SiteId,
            request.SiteName, request.AddressLongitude,
            request.AddressLatitude, request.AddressName,
            request.AppointmentDate);

        _userRepository.Update(user);
        await _userRepository.UnitOfWork.SaveEntitiesAsync();
        return new BusinessResult(BusinessCode.Success, "创建成功");
    }

    public async Task<BusinessResult> CancelAppointmentAsync(CancelAppointmentRequestDTO request)
    {
        var user = await _userRepository.GetAsync(request.UserId);

        user.CancelAppointment(request.AppointmentRecordId);

        _userRepository.Update(user);
        await _userRepository.UnitOfWork.SaveEntitiesAsync();

        return new BusinessResult(BusinessCode.Success, "取消成功");
    }

    public async Task<BusinessResult> GetCurrentAppointmentStatusAsync(Guid userId)
    {
        var user = await _userRepository.GetAsync(userId);

        if (user.IsVaccinationDone())
        {
            return new BusinessResult(BusinessCode.VaccinationDone, "已经完成了疫苗");
        }

        if (user.IsAppointmentInProgress())
        {
            return new BusinessResult(BusinessCode.AppointmentInProgress, "有未完成的预约记录");
        }

        var nextRecommendedAppointment = user.NextRecommendedAppointment();

        if (nextRecommendedAppointment != null)
        {
            return new BusinessResult<CurrentAppointmentStatusResponseDTO>(BusinessCode.AppointmentRecommended, "下次预约时间建议", new CurrentAppointmentStatusResponseDTO
            {
                SerialNumber = nextRecommendedAppointment.SerialNumber,
                NextIntervalDays = nextRecommendedAppointment.NextIntervalDays,
                SiteId = nextRecommendedAppointment.SiteId,
            });
        }

        return new BusinessResult(BusinessCode.AppointmentNotFound, "无预约记录");
    }
}
