

using System.Data;
using System.Data.SqlClient;

namespace Infra.EF;

public class DapperDBContext //: IDapperDBContext
{

    private readonly string _connectionString;
    public DapperDBContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);

}
