using System.Data;
using MySql.Data.MySqlClient;

namespace Webapp;

public class DbUtils
{
    public static IDbConnection Connect()
    {
        return new MySqlConnection(
            "Server=127.0.0.1;Port=3306;" +
            "Database=mydb;" +
            "Uid=root;Pwd=123aukiboy123;"
        );
    }
}