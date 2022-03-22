//TODO Fix this

namespace Webapp.Pages;
using Dapper;

public class AddEntryRepo
{
    public Entry AddEntries(Entry entry)
    {
        using var db = DbUtils.Connect();
        var parameters = new {Name = entry.Name, Series = entry.Series, Author = entry.Author, ReleaseDate = entry.Date, Print = entry.Print, Summary = entry.Summary};
        var sql = @"INSERT INTO comic_information (Name, Series, Author, Release_Date, Print, Summary) 
                    VALUES (@Name, @Series, @Author, @ReleaseDate, @Print, @Summary);";
        db.Execute(sql, parameters);

        return entry;
    }
}