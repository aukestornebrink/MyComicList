using System.Data;
using MySql.Data.MySqlClient;

namespace Webapp;

public class DbUtils
{
    public static IDbConnection Connect()
    {
        return new MySqlConnection(
            "Server=thefrisiangamer.nl;Port=3306;" +
            "Database=comics;" +
            "Uid=project;Pwd=hetwerktniet;"
        );
    }
}