using Dapper;
using Webapp.Pages;

namespace Webapp;

public class PersonalListRepo
{
    public List<PersonalLists> GetPersList(int order) //Fill list with SQL data
    {
        var parameters = new {Order = order}; //Parameter for order
        using var db = DbUtils.Connect(); //Use connect string in DbUtils.cs
        var sql =
            @"SELECT Name, Series, Summary, Photo_front, Person
            FROM Comic INNER JOIN Bijdrage ON Comic.Comic_ID = Bijdrage.Comic_ID
            INNER JOIN Contributor on Bijdrage.Contributer_ID = Contributor.Contributor_ID
            WHERE Functie = 'Author'
            ORDER BY (CASE WHEN @Order = 0 THEN Name WHEN @Order = 1 
                THEN Series WHEN @Order = 2 THEN Person END)"; //SQL Query
        return db.Query<PersonalLists>(sql, parameters).ToList(); //Return filled list
    }
}