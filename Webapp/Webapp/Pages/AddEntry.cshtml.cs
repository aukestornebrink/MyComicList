//TODO Fix this 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages;

namespace Webapp;

public class AddEntry : PageModel
{
    private string Photo_front;
    private string Photo_back;
    // private string Name;
    //private string Series;
    //private string Release_Date;
    //private int Print { get; set; }
    private string Descent;
    //private string Summary { get; set; }
    private string Genre;
    private string Language;
    //private string Author;
    private string Illustrator;

    private IWebHostEnvironment Environment;
    public string Message { get; set; }
 
    // [BindProperty(Name = "NameInput")]
    // public string Name { get; set; }
    //
    // [BindProperty(Name = "SeriesInput")]
    // public string Series { get; set; }
    //
    // [BindProperty(Name = "AuthorInput")]
    // public string Author { get; set; }
    //
    // [BindProperty(Name = "DateInput")]
    // public string ReleaseDate { get; set; }
    //
    // [BindProperty(Name = "PrintInput")]
    // public int Print { get; set; }
    //
    // [BindProperty(Name = "SummaryInput")]
    // public string Summary { get; set; }
    
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
                    Photo_front = fileName;
                }
            }

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }
        }
        
        //Upload back image file
        foreach (IFormFile postedFile in backPosted) //Find way to deprecate foreach loop since there's only one file uploaded
        {
            string fileName = null;
            int i = 0;
            string extension = Path.GetExtension(postedFile.FileName);
            while (i == 0)
            {
                fileName = Path.GetRandomFileName();
                fileName = Path.ChangeExtension(fileName, extension);

                if (!System.IO.File.Exists(fileName))
                {
                    i++;
                    Photo_back = fileName;
                }
            }

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }
        }
        
        var addEntry = new AddEntryRepo().AddEntries(Entry);
        Message = Entry.Author;
    }
}