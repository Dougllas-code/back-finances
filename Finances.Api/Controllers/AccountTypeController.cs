using Finances.Commands.AccountType;
using Finances.Handlers;
using Finances.Infra.Common;
using Finances.Infra.Common.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AccountTypeController : ControllerBase
    {
        private readonly AcccountTypeHandler _accountTypeHandler;
        private readonly ILogger<AccountTypeController> _logger;

        public AccountTypeController(AcccountTypeHandler accountTypeHandler, ILogger<AccountTypeController> logger)
        {
            _accountTypeHandler = accountTypeHandler;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ICommandResult>>
            CreateAsync([FromBody] AccountTypeCommandCreate command)
        {
            try
            {
                _logger.LogInformation("Iniciando criação do registro.");
                var response = await _accountTypeHandler.Handle(command);

                if (response.Type == CommandResultType.Error)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao salvar registro.");
                return BadRequest(error.Message);
            }

        }
    }
}
