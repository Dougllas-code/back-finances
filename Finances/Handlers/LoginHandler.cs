using Finances.Commands;
using Finances.Commands.Generic;
using Finances.Infra.Common;
using Finances.Infra.Common.Enum;
using Finances.Queries;
using Finances.Repositories;
using Flunt.Notifications;
using Microsoft.Extensions.Logging;

namespace Finances.Handlers
{
    public class LoginHandler : Notifiable<Notification>, ICommandHandler<LoginCommand>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly ILogger<LoginHandler> _logger;

        public LoginHandler(
            ILoginRepository loginRepository,
            ITokenRepository tokenRepository,
            ILogger<LoginHandler> logger
        )
        {
            _loginRepository = loginRepository;
            _tokenRepository = tokenRepository;
            _logger = logger;
        }

        public async Task<ICommandResult> Handle(LoginCommand command)
        {
            if (!command.IsValid)
            {
                _logger.LogError($"Command inválido: {command}");
                return new GenericCommandResult(CommandResultType.Error, "Corriga as inconsistências.", Notifications);
            }

            _logger.LogInformation("Calculando Hash");
            var passwordHash = _loginRepository.GenerateHash(command.Password);

            _logger.LogInformation("Buscando usuário");
            var user = await _loginRepository.GetUser(command.Email, passwordHash);

            if (user == null)
            {
                _logger.LogError("Usuário não encontrado");
                return new GenericCommandResult(CommandResultType.NotFound, "Usuário não encontrado.", command.Email);
            }

            _logger.LogInformation("Gerando token");
            var token = _tokenRepository.GenerateToken(user);

            _logger.LogInformation("Gerando QueryResult");
            var result = new LoginQueryResult(user, token);

            return new GenericCommandResult(CommandResultType.Success, "Usuário autenticado com sucesso", result);
        }
    }
}
