using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dapper;

namespace Webapp.Pages;

public class SearchModel : PageModel
{

    [BindProperty]
    public string Search { get; set; }
    
    public void OnPost()
    {
        using var db = DbUtils.Connect();
        
        var parameters = new {SearchInput = Search};
        var sql = "SELECT * FROM comics.comic_information WHERE Name LIKE @SearchInput";
        var result = db.Query(sql, parameters);
        
        Console.Write(result);
        Debug.Write(result);
    }
}