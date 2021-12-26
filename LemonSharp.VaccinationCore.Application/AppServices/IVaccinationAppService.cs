using LemonSharp.VaccinationCore.Application.DTOs;

namespace LemonSharp.VaccinationCore.Application.AppServices;

public interface IVaccinationAppService
{
    Task<BusinessResult> CreateVaccinationPlanAsync(CreateVaccinationRequestDTO request);
    Task<BusinessResult> UpdateVaccinationPlanAsync(UpdateVaccinationRequestDTO request);
}
