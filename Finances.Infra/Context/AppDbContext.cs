using MySql.Data.MySqlClient;

namespace Finances.Infra.Context
{
    public class AppDbContext: IAsyncDisposable
    {
        public MySqlConnection Connection { get; set; }

        public AppDbContext()
        {
            Connection = new MySqlConnection("server=localhost;user id=root;password=Smidvarg0091;database=finances;persistsecurityinfo=False");
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
