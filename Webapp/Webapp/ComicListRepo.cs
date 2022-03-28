using Dapper;

namespace Webapp;

public class ComicListRepo
{
    public List<ComicList> GetList()
    {
        using var db = DbUtils.Connect();
        var sql =
            @"SELECT Name, Comic_ID FROM Comic";
        return db.Query<ComicList>(sql).ToList();
    }
}