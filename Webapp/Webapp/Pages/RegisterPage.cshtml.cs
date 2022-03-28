using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Webapp.Pages;     

public class RegisterPage : PageModel
{
   
    [BindProperty]
    public Registermodel Registermodel { get; set; }
    
    private readonly UserManager<IdentityUser> userManager;

    private readonly SignInManager<IdentityUser> signInManager;

    public void OnGet()
    {
    }

    public RegisterPage Model { get; set; }

    public RegisterPage(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        //if (Username.Equals("abc") && Password.Equals("123"))
       // {
        //    HttpContext.Session.SetString("username", Username);
      //     return RedirectToPage("Welcome");
      //  }
      //  else
       // {
       //     Msg = "Invalid";
       //     return Page();
       // }
       if (ModelState.IsValid)
       {
           var user = new IdentityUser()
           {
               UserName = Registermodel.UserName,
               Email = Registermodel.UserName
           };
           var result = await userManager.CreateAsync(user, Registermodel.UserName);
           if (result.Succeeded)
           {
               await signInManager.SignInAsync(user, false);
               return RedirectToPage("index");
           }

           foreach (var error in result.Errors)
           {
               ModelState.AddModelError("", error.Description); 
           }
       }

       return Page();
    }
}
