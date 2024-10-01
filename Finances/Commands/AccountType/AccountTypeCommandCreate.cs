using Finances.Infra.Common;
using Flunt.Notifications;
using Flunt.Validations;

namespace Finances.Commands.AccountType
{
    public class AccountTypeCommandCreate : Notifiable<Notification>, ICommandDefault
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public bool Valid()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "O campo Name é obrigatótio.")
                .IsNotNullOrEmpty(Color, "Color", "O campo Color é obrigatório.")
            );

            return IsValid;
        }
    }
}
