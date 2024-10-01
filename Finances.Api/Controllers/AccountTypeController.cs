using Finances.Commands.AccountType;
using Finances.Handlers;
using Finances.Infra.Common;
using Finances.Infra.Common.Enum;
using Finances.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AccountTypeController : ControllerBase
    {
        private readonly AcccountTypeHandler _accountTypeHandler;
        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly ILogger<AccountTypeController> _logger;

        public AccountTypeController(
            AcccountTypeHandler accountTypeHandler,
            IAccountTypeRepository accountTypeRepository,
            ILogger<AccountTypeController> logger
        )
        {
            _accountTypeHandler = accountTypeHandler;
            _accountTypeRepository = accountTypeRepository;
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

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<ICommandResult>>
            GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Iniciando busca dos registros.");
                var response = await _accountTypeRepository.GetAll();

                return Ok(response);
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao buscar registros.");
                return BadRequest(error.Message);
            }

        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ICommandResult>>
            UpdateAsync([FromBody] AccountTypeCommandUpdate command)
        {
            try
            {
                _logger.LogInformation("Iniciando atualização do registro.");
                var response = await _accountTypeHandler.Handle(command);

                if (response.Type == CommandResultType.Error)
                    return BadRequest(response);
                
                if (response.Type == CommandResultType.NotFound)
                    return NotFound(response);

                return Ok(response);
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao atualizar registro.");
                return BadRequest(error.Message);
            }

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<ICommandResult>>
            DeleteAsync([FromQuery] AccountTypeCommandDelete command)
        {
            try
            {
                _logger.LogInformation("Iniciando atualização do registro.");
                var response = await _accountTypeHandler.Handle(command);

                if (response.Type == CommandResultType.Error)
                    return BadRequest(response);
                
                if (response.Type == CommandResultType.NotFound)
                    return NotFound(response);

                return NoContent();
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao atualizar registro.");
                return BadRequest(error.Message);
            }

        }
    }
}
