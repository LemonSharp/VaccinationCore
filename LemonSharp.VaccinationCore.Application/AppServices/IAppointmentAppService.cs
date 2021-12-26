using LemonSharp.VaccinationCore.Application.DTOs;

namespace LemonSharp.VaccinationCore.Application.AppServices;

public interface IAppointmentAppService
{
    Task<BusinessResult> CreateAppointmentAsync(CreateAppointmentRequestDTO request);
    
    Task<BusinessResult> CancelAppointmentAsync(CancelAppointmentRequestDTO request);
    Task<BusinessResult> GetCurrentAppointmentStatusAsync(Guid userId);
}
