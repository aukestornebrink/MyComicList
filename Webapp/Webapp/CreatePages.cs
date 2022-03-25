namespace Webapp;

public class CreatePages
{
    public static List<ComicList> List { get; set; }

    public static void ListThings()
    {
        List = new ComicListRepo().GetList();

        string str1 = @"";
    }
}