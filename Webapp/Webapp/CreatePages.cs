namespace Webapp;

public class CreatePages
{
    public static List<ComicList> List { get; set; }
    private static int ID = 2;
    private static string Name = null;
    private static FileStream fs = null;

    public static void ListThings()
    {
        List = new ComicListRepo().GetList();

        foreach (var comic in List)
        {
            Name = comic.Name;
            ID = comic.Comic_ID;
            string fileLoc1 = "Pages/Comic/" + ID + ".cshtml";
            string fileLoc2 = "Pages/Comic/comic" + ID + ".cshtml.cs";
            
            string str1 = @"@page" + Environment.NewLine +
                          "@model comic" + ID + Environment.NewLine +
                          "@{ViewData[\"Title\"] = " + Name + ";}" + Environment.NewLine +
                          Environment.NewLine + "<html lang=\"en\">" + Environment.NewLine +
                          "<head>" + Environment.NewLine + "    <title>Personal List</title>" + Environment.NewLine +
                          " <link rel=\"stylesheet\" href=\"~/css/comicpage\" asp-append-version=\"true\"/>" +
                          Environment.NewLine + "</head>" + Environment.NewLine + Environment.NewLine;

            string str2 = @"<body>" + Environment.NewLine +
                          " <div>" + Environment.NewLine +
                          "     <h1>@Model.Name</h1>" + Environment.NewLine +
                          " </div>" + Environment.NewLine + "</body>";

            string cs1 = @"using Microsoft.AspNetCore.Mvc.RazorPages;" + Environment.NewLine +
                         "namespace Webapp.Pages.Comic;" + Environment.NewLine + Environment.NewLine +
                         "public class comic" + ID + " : PageModel" + Environment.NewLine +
                         "{" + Environment.NewLine + "private int ID = " + ID + ";" + Environment.NewLine +
                         "public List<ComicEntry> List { get; set; }" +
                         Environment.NewLine + "public void OnGet()" + Environment.NewLine +
                         "{" + Environment.NewLine + "List = new ComicEntryRepo().GetList(ID);" +Environment.NewLine +
                         "}" + Environment.NewLine + "}";

            if (!File.Exists(fileLoc1))
            {
                using (fs = File.Create(fileLoc1))
                {
                }

                if (File.Exists(fileLoc1))
                {
                    using StreamWriter sw = new StreamWriter(fileLoc1);
                    sw.Write(str1 + str2);
                }
            }
            
            if (!File.Exists(fileLoc2))
            {
                using (fs = File.Create(fileLoc2))
                {
                }

                if (File.Exists(fileLoc2))
                {
                    using StreamWriter sw = new StreamWriter(fileLoc2);
                    sw.Write(cs1);
                }
            }

            break;
        }
    }
}