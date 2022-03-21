using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webapp.Pages;

public class PersonalList : PageModel
{
    public List<PersonalLists> List { get; set; }

    private int order = 0;
    
    public void OnGet()
    {
        List = new PersonalListRepo().GetPersList(order);
    }

    public void OnPostNameButton()
    {
        order = 0;
        OnGet();
    }

    public void OnPostSeriesButton()
    {
        order = 1;
        OnGet();
    }

    public void OnPostAuthorButton()
    {
        order = 2;
        OnGet();
    }
}