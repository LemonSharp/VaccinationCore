using System.Text;
using Dapper;
using LemonSharp.VaccinationCore.Query.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LemonSharp.VaccinationCore.Query;

public class AppointmentQueries: IAppointmentQueries
{
    private readonly string _connString;
    public AppointmentQueries(IConfiguration configuration)
    {
        _connString = configuration.GetConnectionString("Default");
    }

    public async Task<AppointmentItemDTO[]> GetAppointmentList(AppointmentListRequestDTO request)
    {
        var sqlBuilder = new StringBuilder("SELECT * FROM [dbo].[AppointmentRecords] WHERE 1=1");
        if (request.UserId.HasValue)
        {
            sqlBuilder.Append(" AND UserId=@UserId");
        }
        if (request.Status.HasValue)
        {
            sqlBuilder.Append(" AND Status=@Status");
        }
        var sql = sqlBuilder.ToString();
        await using var conn = new SqlConnection(_connString);
        return (await conn.QueryAsync<AppointmentItemDTO>(sql, request)).ToArray();
    }
}
