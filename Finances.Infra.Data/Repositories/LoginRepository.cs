using Dapper;
using Finances.Entities;
using Finances.Infra.Context;
using Finances.Infra.Data.Queries;
using Finances.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace Finances.Infra.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        private readonly SHA256 _sha256;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
            _sha256 = SHA256.Create();
        }

        public string GenerateHash(string password)
        {
            var bytes = ASCIIEncoding.ASCII.GetBytes(password);
            var hash = _sha256.ComputeHash(bytes);

            return ByteArrayToString(hash);
        }

        private static string ByteArrayToString(byte[] value)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(value.Length);
            for (i = 0; i < value.Length; i++)
            {
                sOutput.Append(value[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        public async Task<User?> GetUser(string email, string passwordHash)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Email", email);
            parameters.Add("Password", passwordHash);

            var query = LoginQueries.GET_USER;

            using var connection = _context.Connection;
            var user = await connection.QueryFirstOrDefaultAsync<User>(query, parameters);
            return user;
        }
    }
}
