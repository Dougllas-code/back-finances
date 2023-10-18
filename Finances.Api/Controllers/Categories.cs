using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        private readonly ILogger<Categories> _logger;

        public Categories(ILogger<Categories> logger) {
            _logger = logger;
        }

        [HttpGet("GetCategories")]
        public async Task<dynamic> GetAllCategories()
        {
            return await GetAllCategories();
        }

    }
}
