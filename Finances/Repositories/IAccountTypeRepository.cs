using Finances.Entities;
using Finances.Queries;

namespace Finances.Repositories
{
    public interface IAccountTypeRepository
    {
        public Task<List<AccountTypeQueryResult>> GetAll();
        public Task<AccountTypeQueryResult?> Get(int id);
        public Task<int> Create(AccountType accountType);
        public Task<int> Update(AccountType accountType);
        public Task<dynamic> Delete(int Id);
    }
}
