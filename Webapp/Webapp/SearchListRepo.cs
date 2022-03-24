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

    public List<SearchLists> GetSearchList(string Search)
    {
        Debug.Write(Search);
        var parameters = new {SearchInput = Search};
        using var db = DbUtils.Connect();
        return db.Query<SearchLists>(@"SELECT * FROM comics.Comic WHERE Name LIKE @SearchInput").ToList();
    }
}

