using Finances.Infra.Common;
using Flunt.Notifications;
using Flunt.Validations;

namespace Finances.Commands
{
    public class LoginCommand: Notifiable<Notification>, ICommandDefault
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Valid()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Email, "Email", "O campo Email é obrigatótio.")
                .IsNotNullOrEmpty(Password, "Password", "O campo Password é obrigatório.")
            );

            return IsValid;
        }
    }
}
