using Dapper;
using Webapp.Pages;

namespace Webapp;

public class PersonalListRepo
{
    // public class ListInfo
    // {
    //     public string Name { get; set; }
    //     public string Series { get; set; }
    //     public string Summary { get; set; }
    //     public string Author { get; set; }
    // }

    public List<PersonalLists> GetPersList()
    {
        using var db = DbUtils.Connect();
        return db.Query<PersonalLists>("SELECT Name, Series, Summary, Author FROM testdb.comic_information").ToList();
    }
}