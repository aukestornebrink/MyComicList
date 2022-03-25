using Dapper;

namespace Webapp;

public class ComicListRepo
{
    public List<ComicList> GetList() //Fill list with SQL data
    {
        using var db = DbUtils.Connect(); //Use connect string in DbUtils.cs
        var sql =
            @"SELECT Name, Series, Summary, Photo_front, Person, Release_date, Print, Language, Genre
            FROM Comic INNER JOIN Bijdrage ON Comic.Comic_ID = Bijdrage.Comic_ID
            INNER JOIN Contributor on Bijdrage.Contributer_ID = Contributor.Contributor_ID
            WHERE Functie = 'Author'"; //SQL Query
        return db.Query<ComicList>(sql).ToList(); //Return filled list
    }
}