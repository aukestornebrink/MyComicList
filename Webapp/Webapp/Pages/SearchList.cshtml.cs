using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webapp.Pages;


public class SearchList : PageModel
{
    [BindProperty]
    public string Search { get; set; }

    private string SearchBy = "Name";
    public void OnGet()
    {
        Lists = new SearchListRepo().GetSearchList(Search, SearchBy);

    }
    public List<SearchLists> Lists { get; set; }
    public void OnPost()
    {
        Lists = new SearchListRepo().GetSearchList(Search, SearchBy);
    }
    
    /*  public void OnPostSearchByName()
    {
        SearchBy = "Name"; //Set order for case in SQL query
    }

    public void OnPostSearchBySeries()
    {
        SearchBy = "Series"; //Set order for case in SQL query
    }

    public void OnPostSearchByAuthor()
    {
        SearchBy = "Author"; //Set order for case in SQL query
    }*/
}

