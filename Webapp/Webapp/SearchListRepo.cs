using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Webapp.Pages;

namespace Webapp;

public class SearchListRepo
{
    // public class ListInfo
    // {
    //     public string Name { get; set; }
    //     public string Series { get; set; }
    //     public string Summary { get; set; }
    //     public string Author { get; set; }
    // }

    public List<SearchLists> GetSearchList(string Search, string SearchBy)
    {
        using var db = DbUtils.Connect();
        var parameters = new DynamicParameters();
        parameters.Add("@SearchBySort", SearchBy);
        parameters.Add("@SearchInput", Search);

        return db.Query<SearchLists>(@"SELECT * FROM comics.Comic WHERE Comic.Name LIKE @s", new {s = "%"+Search+"%"}).ToList();
    }
}

