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

namespace Webapp.Pages;

public class LoginPage : PageModel
{


    [BindProperty]
    public string Message { get; set; }
    
    public void OnPostTestButton()
    {
        Message = "TEST";
        
        string email = "email";
        string mycon = "server=localhost:3306; Uid=root; password=123aukiboy123; persistsecurityinfo=True; database=mydb; SslMode= none";

        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        try
        {
            cmd.Parameters.AddWithValue("@a1", email);
            cmd = new MySqlCommand(
                "insert into account(Username, Email, Password, Rank) values ('Test', 'Test','Test', '1')");


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception ex)
        {
            Response.WriteAsync("<script>alert('" + ex.Message + "')</script>");
            con.Close();
            return;
        }

        Response.WriteAsync("<script>alert('Data saved successfully')</script>");
    }

}