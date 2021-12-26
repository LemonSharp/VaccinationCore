using LemonSharp.VaccinationCore.Application.DTOs;
using LemonSharp.VaccinationCore.Domain;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.AggregatesModel.VaccinationPlanAggregate;

namespace LemonSharp.VaccinationCore.Application.AppServices;

public class VaccinationAppService : IVaccinationAppService
{
    private readonly IVaccinationPlanRepository _vaccinationPlanRepository;

    public VaccinationAppService(IVaccinationPlanRepository vaccinationPlanRepository)
    {
        _vaccinationPlanRepository = vaccinationPlanRepository;
    }

    public async Task<BusinessResult> CreateVaccinationPlanAsync(CreateVaccinationRequestDTO request)
    {
        var plan = new VaccinationPlan(request.UserId, request.TotalCount, request.Internals);
        _vaccinationPlanRepository.Add(plan);
        await _vaccinationPlanRepository.UnitOfWork.SaveEntitiesAsync();
        return new BusinessResult(BusinessCode.Success, "创建接种计划成功");
    }

    public async Task<BusinessResult> UpdateVaccinationPlanAsync(UpdateVaccinationRequestDTO request)
    {
        var plan = await _vaccinationPlanRepository.GetAsync(request.PlanId);
        plan.Vaccinate(request.SerialNumber);
        _vaccinationPlanRepository.Update(plan);
        await _vaccinationPlanRepository.UnitOfWork.SaveEntitiesAsync();
        
        return new BusinessResult(BusinessCode.Success, "更新接种进度成功");
    }
}
