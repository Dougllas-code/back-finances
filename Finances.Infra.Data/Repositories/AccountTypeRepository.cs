using Dapper;
using Finances.Entities;
using Finances.Infra.Context;
using Finances.Infra.Data.Queries;
using Finances.Queries;
using Finances.Repositories;
using System.Data;

namespace Finances.Infra.Data.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly AppDbContext _context;
        public AccountTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        private IDbConnection GetConnection()
        {
            return _context.Connection;
        }

        public async Task<int> Create(AccountType accountType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", accountType.Name);
            parameters.Add("Color", accountType.Color);

            var query = AccountTypeQueries.CREATE;

            using var connection = GetConnection();
            var result = await connection.QuerySingleAsync<int>(query, parameters);
            return result;
        }

        public Task<dynamic> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AccountTypeQueryResult>> GetAll()
        {
            var query = AccountTypeQueries.GET_ALL;

            using var connection = GetConnection();
            var result = await connection.QueryAsync<AccountTypeQueryResult>(query);
            return result.ToList();
        }

        public async Task<AccountTypeQueryResult?> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);

            var query = AccountTypeQueries.GET;

            using var connection = GetConnection();
            var result = await connection.QueryFirstOrDefaultAsync<AccountTypeQueryResult>(query, parameters);
            return result;
        }

        public async Task<int> Update(AccountType accountType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", accountType.Id);
            parameters.Add("Name", accountType.Name);
            parameters.Add("Color", accountType.Color);

            var query = AccountTypeQueries.UPDATE;

            using var connection = GetConnection();
            var result = await connection.ExecuteAsync(query, parameters);
            return result;
        }
    }
}
