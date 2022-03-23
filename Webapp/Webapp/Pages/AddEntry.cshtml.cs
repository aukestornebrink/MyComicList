//TODO Fix this 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages;

namespace Webapp;

public class AddEntry : PageModel
{
    private string Photo;

    private IWebHostEnvironment Environment;
    public string Message { get; set; }

    [BindProperty]
    public Entry Entry { get; set; }
    
    public AddEntry(IWebHostEnvironment _environment)
    {
        Environment = _environment;
    }

    public void OnGet()
    {
 
    }

    // public void OnPostUpload()
    // {
    //     var addEntry = new AddEntryRepo().AddEntries(Entry);
    // }
 
    public void OnPostUpload(List<IFormFile> frontPosted, List<IFormFile> backPosted)
    {
        // DateTime date1 = DateTime.Parse(ReleaseDate,
        //     System.Globalization.CultureInfo.InvariantCulture);
        // string sqlFormattedDate = date1.ToString("yyyy-MM-dd");
        
        
        
        
        
        
        string path = Path.Combine(this.Environment.WebRootPath, "content");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        //Upload front image file
        foreach (IFormFile postedFile in frontPosted) //Find way to deprecate foreach loop since there's only one file uploaded
        {
            string fileName = null;
            int i = 0;
            string extension = Path.GetExtension(postedFile.FileName); //Get extension of uploaded file
            while (i == 0)
            {
                fileName = Path.GetRandomFileName(); //Create a random file name
                fileName = Path.ChangeExtension(fileName, extension); //Change randomised extension back into original

                if (!System.IO.File.Exists(fileName)) //Check if there's no file with the same name
                {
                    i++;
                    Photo = fileName;
                }
            }

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }
        }

        var addEntry = new AddEntryRepo().AddEntries(Entry, Photo);
    }
}