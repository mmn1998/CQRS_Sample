using CQRS_Sample.Application.Contracts.Models.Queries.SomeModels;
using CQRS_Sample.Domain.Models.SomeModels;
using CQRS_Sample.Persistence.Query.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CQRS_Sample.Persistence.Query.Repositories.SomeModels;

public class SomeModelQueryRepository : ISomeModelQueryRepository
{
    private readonly string _connectionString;
    private readonly string _mainQuery;
    public SomeModelQueryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString();
        _mainQuery = @"
SELECT [Id]
      ,[Name]
  FROM [SomeModels]
";
    }
    public async Task<IEnumerable<GetSomeModelQueryResult>> GetAll(GetAllSomeModelsQuery request)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var query = $@"{_mainQuery}";
        return await connection.QueryAsync<GetSomeModelQueryResult>(query);
    }

    public async Task<GetSomeModelQueryResult> GetById(GetSomeModelQuery request)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var query = $@"{_mainQuery} Where Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<GetSomeModelQueryResult>(query, new { Id = request.Id }) ?? throw new KeyNotFoundException();
    }

    public async Task SyncData_Add(CreateSomeModelArg entity)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var query = @"
Insert Into SomeModels (Id, Name)
Values (@Id, @Name)
";
        await connection.ExecuteAsync(query, new { Id = entity.Id, Name = entity.Name });
    }

    public async Task SyncData_Delete(long id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var query = @"
Delete from SomeModels
Where Id=@Id
"
        ;
        await connection.ExecuteAsync(query, new { Id = id });
    }

    public async Task SyncData_Edit(ModifySomeModelArg entity)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var query = @"
Update SomeModels (Id, Name)
Set Name=@Name
Where Id = @Id
";
        await connection.ExecuteAsync(query, new { Id = entity.Id, Name = entity.Name });
    }
}
