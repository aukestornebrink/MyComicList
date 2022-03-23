//TODO Fix this

namespace Webapp.Pages;
using Dapper;

public class AddEntryRepo
{
    public Entry AddEntries(Entry entry, string Photo)
    {
        using var db = DbUtils.Connect();
        var parameters = new {Name = entry.Name, Series = entry.Series, ReleaseDate = entry.Date, Print = entry.Print, Summary = entry.Summary};
        var sql = @"INSERT INTO Comic (Name, Series, Release_Date, Print, Summary, Language, Genre) 
                    VALUES (@Name, @Series, @ReleaseDate, @Print, @Summary, @Language, @Genre);";
        db.Execute(sql, parameters);

        return entry;
    }
}