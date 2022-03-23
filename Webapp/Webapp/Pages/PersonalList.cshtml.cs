using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webapp.Pages;

public class PersonalList : PageModel
{
    public List<PersonalLists> List { get; set; } //Create list called List

    private int order = 0; //Initialize
    
    public void OnGet()
    {
        List = new PersonalListRepo().GetPersList(order); //Create list from GetPersList
    }

    public void OnPostNameButton()
    {
        order = 0; //Set order for case in SQL query
        OnGet(); //Reload List
    }

    public void OnPostSeriesButton()
    {
        order = 1; //Set order for case in SQL query
        OnGet(); //Reload List
    }

    public void OnPostAuthorButton()
    {
        order = 2; //Set order for case in SQL query
        OnGet(); //Reload List
    }
}