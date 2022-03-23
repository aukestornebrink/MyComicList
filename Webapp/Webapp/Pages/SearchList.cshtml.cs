using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webapp.Pages;


public class SearchList : PageModel
{
    [BindProperty]
    public string Search { get; set; }
    
    public void OnGet()
    {

    }
    public List<SearchLists> Lists { get; set; }
    public void OnPost()
    {
        Lists = new SearchListRepo().GetSearchList(Search);
    }
}

