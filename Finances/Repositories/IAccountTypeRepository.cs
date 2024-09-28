using Finances.Commands.AccountType;
using Finances.Entities;

namespace Finances.Repositories
{
    public interface IAccountTypeRepository
    {
        public Task<List<AccountType>> GetAll();
        public Task<AccountType?> Get(int id);
        public Task<int> Create(AccountTypeCommandCreate accountType);
        public Task<AccountType> Update(AccountTypeCommandUpdate accountType);
        public Task<dynamic> Delete(int Id);
    }
}
