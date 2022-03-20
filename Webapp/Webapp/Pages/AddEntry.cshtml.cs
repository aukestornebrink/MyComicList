using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webapp;

public class AddEntry : PageModel
{
    private IWebHostEnvironment Environment;
    public string Message { get; set; }
 
    public AddEntry(IWebHostEnvironment _environment)
    {
        Environment = _environment;
    }
 
    public void OnGet()
    {
 
    }
 
    public void OnPostUpload(List<IFormFile> postedFiles)
    {
        string path = Path.Combine(this.Environment.WebRootPath, "content");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
 
        List<string> uploadedFiles = new List<string>();
        foreach (IFormFile postedFile in postedFiles)
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
                }
            }

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                postedFile.CopyTo(stream);
                uploadedFiles.Add(fileName);
                this.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }
        }
    }
}