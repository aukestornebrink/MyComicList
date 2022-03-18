using System.Data;
using MySql.Data.MySqlClient;

namespace Webapp;

public class DbUtils
{
    public static IDbConnection Connect()
    {
        return new MySqlConnection(
            "Server=127.0.0.1;Port=3306;" +
            "Database=testdb;" +
            "Uid=root;Pwd=cfVhSmPwV6sQRD;"
        );
    }
}