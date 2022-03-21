using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Ubiety.Dns.Core;
using Webapp.Pages;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;


namespace Webapp.Pages;

public class LoginPage : PageModel
{


    [BindProperty]
    public string Message { get; set; }

    public void OnPostTestButton()
    {
        string VarName = "ExampleName";
        string VarEmail = "Example@Email.com";
        string VarPass = "ExamplePassword";
        int DefaultRank = 1;

        using var db = DbUtils.Connect();
        
        var parameters = new {UserName = VarName, Email = VarEmail, Password = VarPass, Rank = DefaultRank};
        var sql = "INSERT INTO account (Username, Email, Password, _Rank) values (@UserName, @Email, @Password, @Rank)";
        var result = db.Query(sql, parameters);
    }

}


