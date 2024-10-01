using Finances.Entities;

namespace Finances.Queries
{
    public class AccountTypeQueryResult
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public AccountTypeQueryResult() { }

        public AccountTypeQueryResult(AccountType accountType)
        {
            Id = accountType.Id;
            Name = accountType.Name;
            Color = accountType.Color;
        }
    }
}
