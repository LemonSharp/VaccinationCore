using LemonSharp.VaccinationCore.Domain;

namespace LemonSharp.VaccinationCore.Application.DTOs;

public class BusinessResult
{
    public BusinessCode Code { get; }

    public string Message { get; }
    public BusinessResult(BusinessCode code, string message)
    {
        Code = code;
        Message = message;
    }
}

public class BusinessResult<T> : BusinessResult
{
    public T Data { get; }

    public BusinessResult(BusinessCode code, string message, T data) : base(code, message)
    {
        Data = data;
    }
}
