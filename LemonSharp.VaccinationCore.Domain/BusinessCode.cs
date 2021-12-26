namespace LemonSharp.VaccinationCore.Domain;

public enum BusinessCode
{
    Failed = 0,

    Success = 1,

    AppointmentNotFound = 11,

    AppointmentInProgress = 12,

    AppointmentRecommended = 13,

    VaccinationDone = 14,
}
