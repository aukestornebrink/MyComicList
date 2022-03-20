using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql;
using MySql.Web;
using Dapper;

namespace Webapp.Pages;

public class LoginPage : PageModel
{


    [BindProperty]
    public string Message { get; set; }
    
    public void OnPostTestButton()
    {
        Message = "TEST";


        string cs = @"server=localhost;Uid=root;password=123aukiboy123;database=mydb;";
        
        using var con = new MySqlConnection(cs);
        con.Open();

        try
        {
            var sql = @"INSERT INTO mydb.account (Username,Email,Password,Rank) VALUES(?User, ?Email, ?Password, ?Rank)";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("?User", "Test");
            cmd.Parameters.AddWithValue("?Email", "Test@test.test");
            cmd.Parameters.AddWithValue("?Password", "TestTestPassTest");
            cmd.Parameters.AddWithValue("?Rank", '1');

            cmd.ExecuteNonQuery();
            
            con.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        



        Response.WriteAsync("<script>alert('Data saved successfully')</script>");
    }

}