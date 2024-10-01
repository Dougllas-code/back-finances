using Finances.Infra.Common;
using Flunt.Notifications;
using Flunt.Validations;

namespace Finances.Commands.AccountType
{
    public class AccountTypeCommandUpdate : Notifiable<Notification>, ICommandDefault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public bool Valid()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Id, "Id", "O campo Id é obrigatótio.")
                .IsGreaterThan(Id, 0, "Id", "O campo Id deve ser maior que zero.")
                .IsNotNullOrEmpty(Name, "Name", "O campo Name é obrigatótio.")
                .IsNotNullOrEmpty(Color, "Color", "O campo Color é obrigatório.")
            );

            return IsValid;
        }
    }
}
