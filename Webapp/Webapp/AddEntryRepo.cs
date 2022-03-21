//TODO Fix this

namespace Webapp.Pages;
using Dapper;

public class AddEntryRepo
{
    public static void AddEntries(string fname, string fseries, string fauthor, string freleasedate, string fsynopsys, int fprint)
    {
        string name = fname;
        string series = fseries;
        string author = fauthor;
        string releasedate = freleasedate;
        string synopsys = fsynopsys;
        int print = fprint;
        
        using var db = DbUtils.Connect();

        var parameters = new {Name = name, Series = series, Author = author, ReleaseDate = releasedate, Print = print, Summary = synopsys};
        var sql = "INSERT INTO comic_information (Name, Series, Author, Release_Date, Print, Summary) values (@Name, @Series, @Author, @Release_Date, @Print, @Summary)";
        db.Query(sql, parameters);
    }
}