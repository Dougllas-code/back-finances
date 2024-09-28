using Dapper;
using Finances.Commands.AccountType;
using Finances.Entities;
using Finances.Infra.Context;
using Finances.Infra.Data.Queries;
using Finances.Repositories;

namespace Finances.Infra.Data.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly AppDbContext _context;
        public AccountTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(AccountTypeCommandCreate accountType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", accountType.Name);
            parameters.Add("Color", accountType.Color);

            var query = AccountTypeQueries.CREATE;

            using var connection = _context.Connection;
            var result = await connection.QuerySingleAsync<int>(query, parameters);
            return result;
        }

        public Task<dynamic> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountType>> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public async Task<AccountType?> Get(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);

            var query = AccountTypeQueries.GET;

            using var connection = _context.Connection;
            var result = await connection.QueryFirstOrDefaultAsync<AccountType>(query, parameters);
            return result;
        }

        public Task<AccountType> Update(AccountTypeCommandUpdate accountTye)
        {
            throw new NotImplementedException();
        }
    }
}
