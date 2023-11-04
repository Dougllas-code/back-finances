using Finances.Entities;

namespace Finances.Repositories
{
    public interface ITokenRepository
    {
        public string GenerateToken(User user);
    }
}
