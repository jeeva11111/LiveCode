using Microsoft.Data.SqlClient;
using System.Data;

namespace LiveCode.DapperContext
{
    public class DapperContextModel
    {


        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContextModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ServerLink");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
