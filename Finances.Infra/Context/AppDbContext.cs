using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Finances.Infra.Context
{
    public class AppDbContext: IAsyncDisposable
    {
        public MySqlConnection Connection { get; set; }
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public async ValueTask DisposeAsync()
        {
            await Connection.CloseAsync();
            await Connection.ClearAllPoolsAsync();
            await Connection.DisposeAsync();
        }
    }
}
