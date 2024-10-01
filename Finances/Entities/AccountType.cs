using Finances.Commands.AccountType;
using Flunt.Notifications;

namespace Finances.Entities
{
    public class AccountType : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public AccountType() { }

        public AccountType(int id, string name, string color)
        {
            Id = id;
            Name = name;
            Color = color;
        }

        public AccountType(AccountTypeCommandCreate command)
        {
            Name = command.Name;
            Color = command.Color;

            Validate();
        }

        public AccountType(AccountTypeCommandUpdate command)
        {
            Id = command.Id;
            Name = command.Name;
            Color = command.Color;

            Validate();
        }

        public void Validate()
        {
            ValidateNameLength();
            ValidateColorLength();
        }

        private void ValidateNameLength()
        {
            if (Name != null && Name.Length > 30)
            {
                AddNotification("Name", "O campo Name não pode ter mais de 30 caracteres.");
            }
        }

        private void ValidateColorLength()
        {
            if (Color != null && Color.Length > 8)
            {
                AddNotification("Color", "O campo Color não pode ter mais de 8 caracteres.");
            }
        }
    }
}
