//TODO Fix this

namespace Webapp.Pages;
using Dapper;

public class AddEntryRepo
{
    public Entry AddEntries(Entry entry, string photo)
    {
        using var db = DbUtils.Connect();
        var parameters = new {Name = entry.Name, Series = entry.Series, ReleaseDate = entry.Date, Print = entry.Print, Summary = entry.Summary, Person = entry.Author, Photo = photo, Language = entry.Language, Genre = entry.Genre};
        var comic = @"INSERT INTO Comic (Name, Series, Release_Date, Print, Summary, Language, Genre, Photo_front) 
                    VALUES (@Name, @Series, @ReleaseDate, @Print, @Summary, @Language, @Genre, @Photo)";
        var author = @"INSERT INTO Contributor (Person) VALUES (@Person)";
        db.Execute(comic, parameters);
        //db.Execute(author, parameters);

        return entry;
    }
}