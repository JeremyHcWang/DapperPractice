using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperInfrastructure.Data;

public class PracticeDbContext
{
    private readonly IConfiguration configuration;
    private readonly string connectionString;

    public PracticeDbContext(IConfiguration _configuration)
    {
        configuration = _configuration;
        connectionString = configuration.GetConnectionString("PracticeDbStr");
    }

    public IDbConnection GetDbConnection()
    {
        return new SqlConnection(connectionString);
    }

}