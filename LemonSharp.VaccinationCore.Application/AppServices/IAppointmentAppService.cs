using LemonSharp.VaccinationCore.Application.DTOs;

namespace LemonSharp.VaccinationCore.Application.AppServices;

public interface IAppointmentAppService
{
    Task<BusinessResult> CreateAppointmentAsync(CreateAppointmentRequestDTO request);
    
    Task<BusinessResult> UpdateAppointmentAsync(CancelAppointmentRequestDTO request);
}
