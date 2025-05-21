using System.Threading.Tasks;
using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    private const string connString = "Server=localhost;Database=crm_db-20-05;User Id=postgres;Password=12345";

    public Task<NpgsqlConnection> GetConnectionAsync()
    {
        return Task.FromResult(new NpgsqlConnection(connString));
    }
}
