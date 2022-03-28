using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Webapp;

public class comic1 : PageModel
{
private int ID = 1;
public List<ComicEntry> List { get; set; }
public void OnGet()
{
List = new ComicEntryRepo().GetList(ID);
}
}