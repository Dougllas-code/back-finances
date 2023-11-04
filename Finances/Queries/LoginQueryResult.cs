using Finances.Entities;

namespace Finances.Queries
{
    public class LoginQueryResult
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Token { get; private set; }

        public LoginQueryResult(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Token = token;
        }
    }
}
