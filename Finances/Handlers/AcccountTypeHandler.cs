using Finances.Commands.AccountType;
using Finances.Commands.Generic;
using Finances.Entities;
using Finances.Infra.Common;
using Finances.Infra.Common.Enum;
using Finances.Repositories;
using Flunt.Notifications;
using Microsoft.Extensions.Logging;

namespace Finances.Handlers
{
    public class AcccountTypeHandler :
        Notifiable<Notification>,
        ICommandHandler<AccountTypeCommandCreate>,
        ICommandHandler<AccountTypeCommandUpdate>
    {

        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly ILogger<AcccountTypeHandler> _logger;

        public AcccountTypeHandler(
            IAccountTypeRepository accountTypeRepository,
            ILogger<AcccountTypeHandler> logger
        )
        {
            _accountTypeRepository = accountTypeRepository;
            _logger = logger;
        }

        public async Task<ICommandResult> Handle(AccountTypeCommandCreate command)
        {
            if (!command.IsValid)
            {
                _logger.LogError($"Command inválido: {command}");
                return new GenericCommandResult(CommandResultType.Error, "Corriga as inconsistências.", Notifications);
            }

            _logger.LogInformation($"Criando e validando entidade");
            var accountType = new AccountType(command);

            if (!accountType.IsValid)
            {
                _logger.LogError($"Entidade inválida: {accountType}");
                return new GenericCommandResult(CommandResultType.Error, "Corriga as inconsistências.", Notifications);
            }

            _logger.LogInformation($"Salvando tipo de conta");
            var accountId = await _accountTypeRepository.Create(accountType);

            if (accountId == 0)
            {
                _logger.LogError($"Erro ao salvar registro");
                return new GenericCommandResult(CommandResultType.Error, "Erro ao criar registro", command.Name);
            }

            _logger.LogInformation($"Buscando registro criado");
            var result = await _accountTypeRepository.Get(accountId);

            _logger.LogInformation($"Tipo de conta salvo com sucesso: {command}");
            return new GenericCommandResult(CommandResultType.Success, "Registro salvo com sucesso", result);
        }

        public async Task<ICommandResult> Handle(AccountTypeCommandUpdate command)
        {
            if (!command.IsValid)
            {
                _logger.LogError($"Command inválido: {command}");
                return new GenericCommandResult(CommandResultType.Error, "Corriga as inconsistências.", Notifications);
            }

            _logger.LogInformation($"Criando e validando entidade");
            var accountType = new AccountType(command);

            if (!accountType.IsValid)
            {
                _logger.LogError($"Entidade inválida: {accountType}");
                return new GenericCommandResult(CommandResultType.Error, "Corriga as inconsistências.", Notifications);
            }

            _logger.LogInformation($"Atualizando tipo de conta");
            var changedLines = await _accountTypeRepository.Update(accountType);

            if (changedLines == 0)
            {
                _logger.LogError($"Erro ao atualizar registro");
                return new GenericCommandResult(CommandResultType.Error, "Erro ao atualizar registro", command.Name);
            }

            _logger.LogInformation($"Buscando registro atualizado");
            var result = await _accountTypeRepository.Get(accountType.Id);

            _logger.LogInformation($"Tipo de conta atualizada com sucesso: {command}");
            return new GenericCommandResult(CommandResultType.Success, "Registro atualizado com sucesso", result);
        }
    }
}
