using Dapper;
using MercurySchool.DataAccess.Connections;
using MercurySchool.Models.Entities;
using System.Data;

namespace MercurySchool.DataAccess.Repositories;

/// <inheritdoc>
public class AccountRepository(IDatabaseConnections _sqlConnection) : IAccountRepository
{
    public async Task<Account> GetAccountAsync(Guid id)
    {
        var storedProcedureName = "api.GetAccount";

        var values = new { Id = id };
        var queryResult = await _sqlConnection.Connection.QueryAsync<Account>(storedProcedureName, values, commandType: CommandType.StoredProcedure);

        return queryResult.FirstOrDefault()!;
    }

    public async Task<bool> InsertAccountAsync(Account account)
    {
        var storedProcedureName = "api.InsertAccount";
        var result = await _sqlConnection.Connection.ExecuteAsync(storedProcedureName, account, commandType: CommandType.StoredProcedure);

        return result > 0;
    }
}