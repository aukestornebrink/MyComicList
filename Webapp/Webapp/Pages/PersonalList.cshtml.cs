using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webapp.Pages;

public class PersonalList : PageModel
{
    public List<PersonalLists> List { get; set; }
    public void OnGet()
    {
        List = new PersonalListRepo().GetPersList();
    }
}