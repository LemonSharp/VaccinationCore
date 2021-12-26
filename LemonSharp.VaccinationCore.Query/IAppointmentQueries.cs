using LemonSharp.VaccinationCore.Query.DTOs;

namespace LemonSharp.VaccinationCore.Query;

public interface IAppointmentQueries
{
    Task<AppointmentItemDTO[]> GetAppointmentList(AppointmentListRequestDTO request);
}
