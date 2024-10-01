using Finances.Infra.Common;
using Flunt.Notifications;
using Flunt.Validations;

namespace Finances.Commands.AccountType
{
    public class AccountTypeCommandDelete: Notifiable<Notification>, ICommandDefault
    {
        public int Id { get; set; }

        public bool Valid()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Id, "O Campo Id não pode ser nulo.")
                .IsGreaterThan(Id, 0, "o Campo Id deve ser maior que 0.")
            );

            return IsValid;
        }
    }
}
