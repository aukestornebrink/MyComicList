using Dapper;
using Webapp.Pages;

namespace Webapp;

public class PersonalListRepo
{
    public List<PersonalLists> GetPersList(int order)
    {
        var parameters = new {Order = order};
        using var db = DbUtils.Connect();
        var sql =
            "SELECT Name, Series, Summary, Photo_front, Author FROM comics.comic_information ORDER BY (CASE WHEN @Order = 0 THEN Name WHEN @Order = 1 THEN Series WHEN @Order = 2 THEN Author END)";
        return db.Query<PersonalLists>(sql, parameters).ToList();
    }
}