using Dapper;
using LemonSharp.VaccinationCore.Query.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LemonSharp.VaccinationCore.Query;

public class VaccinationQueries: IVaccinationQueries
{
    private readonly string _connString;
    public VaccinationQueries(IConfiguration configuration)
    {
        _connString = configuration.GetConnectionString("Default");
    }
    
    public async Task<VaccinationPlanItemDTO[]> GetVaccinationPlanItems(Guid userId)
    {
        var sql = @"SELECT * FROM [dbo].[VaccinationPlanItems] 
WHERE UserId = @userId ORDER BY [SerialNumber]";
        await using var conn = new SqlConnection(_connString);
        return (await conn.QueryAsync<VaccinationPlanItemDTO>(sql, new { userId })).ToArray();
    }
    
    public async Task<VaccinationPlanDTO[]> GetVaccinationPlans(Guid userId)
    {
        var sql = @"SELECT * FROM [dbo].[VaccinationPlans] AS p WHERE p.UserId = @userId";
        await using var conn = new SqlConnection(_connString);
        return (await conn.QueryAsync<VaccinationPlanDTO>(sql, new { userId })).ToArray();
    }
}
