using Finances.Commands;
using Finances.Handlers;
using Finances.Infra.Common;
using Finances.Infra.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        private readonly LoginHandler _loginHandler;
        private readonly ILogger<LoginController> _logger;

        public LoginController(LoginHandler loginHandler, ILogger<LoginController> logger)
        {
            _loginHandler = loginHandler;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ICommandResult>>
            AuthenticateAsync([FromBody] LoginCommand command)
        {
            try
            {
                _logger.LogInformation("Iniciando autenticação.");
                var response = await _loginHandler.Handle(command);

                if (response.Type == CommandResultType.Error)
                    return BadRequest(response);
                else if (response.Type == CommandResultType.NotFound)
                    return NotFound(response);

                return Ok(response);
            }
            catch (Exception error)
            {
                _logger.LogError("Erro ao realizar autenticação.");
                return BadRequest(error.Message);
            }

        }
    }
}
