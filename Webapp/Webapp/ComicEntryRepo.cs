using Dapper;

namespace Webapp;

public class ComicEntryRepo
{
    public List<ComicEntry> GetList(int id) //Fill list with SQL data
    {
        var paramenters = new {ID = id};
        using var db = DbUtils.Connect(); //Use connect string in DbUtils.cs
        var sql =
            @"SELECT Name, Series, Summary, Photo_front, Person, Release_date, Print, Language, Genre
            FROM Comic INNER JOIN Bijdrage ON Comic.Comic_ID = Bijdrage.Comic_ID
            INNER JOIN Contributor on Bijdrage.Contributer_ID = Contributor.Contributor_ID
            WHERE Functie = 'Author' AND Comic.Comic_ID = @id"; //SQL Query
        return db.Query<ComicEntry>(sql, paramenters).ToList(); //Return filled list
    }
}