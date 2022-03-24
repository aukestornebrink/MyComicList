namespace Webapp;
using Dapper;

public class AddEntryRepo
{
    public Entry AddEntries(Entry entry, string photo) //TODO Remove ability to upload duplicates
    {
        using var db = DbUtils.Connect();
        var parameters = new {Name = entry.Name, Series = entry.Series, ReleaseDate = entry.Date, Print = entry.Print, Summary = entry.Summary, Person = entry.Author, Photo = photo, Language = entry.Language, Genre = entry.Genre};
        var comic = @"INSERT INTO Comic (Name, Series, Release_Date, Print, Summary, Language, Genre, Photo_front) 
                    VALUES (@Name, @Series, @ReleaseDate, @Print, @Summary, @Language, @Genre, @Photo);
                    SELECT LAST_INSERT_ID();";
        var author = @"INSERT INTO Contributor (Person) VALUES (@Person)
                        ON DUPLICATE KEY UPDATE Contributor_ID=LAST_INSERT_ID(Contributor_ID), Person='@Person';
                        SELECT LAST_INSERT_ID()";
        int comicid = db.ExecuteScalar<int>(comic, parameters);
        int conid = db.ExecuteScalar<int>(author, parameters);

        var par2 = new {ComicID = comicid, ConID = conid};
        var bijdrage = @"INSERT INTO Bijdrage (Comic_ID, Contributer_ID, Functie) VALUES (@ComicID,@ConID, 'Author')";
        db.Execute(bijdrage, par2);

        return entry;
    }
}