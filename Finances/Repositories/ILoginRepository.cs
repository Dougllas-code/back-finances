using Finances.Entities;

namespace Finances.Repositories
{
    public interface ILoginRepository
    {
        public string GenerateHash(string password);
        public Task<User> GetUser(string email, string passwordHash);
    }
}
