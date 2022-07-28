using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GoodEats.Models;

namespace GoodEats.Repositories
{
  public class RestaurantsRepo
  {

    private readonly IDbConnection _db;

    public RestaurantsRepo(IDbConnection db)
    {
      _db = db;
    }


    public List<Restaurant> Get()
    {
      var sql = @"SELECT 
                r.*, 
                AVG(rev.rating) as AverageRating,
                COUNT(rev.id) as TotalReviews
                FROM restaurants r
                LEFT JOIN reviews rev ON rev.restaurantId = r.id
                GROUP BY r.id;
              ";
      return _db.Query<Restaurant>(sql).ToList();
    }

    public Restaurant Get(int id)
    {
      var sql = @"SELECT 
                r.*, 
                AVG(rev.rating) as AverageRating,
                COUNT(rev.id) as TotalReviews
                FROM restaurants r
                LEFT JOIN reviews rev ON rev.restaurantId = r.id
                GROUP BY r.id WHERE id = @id;";
      return _db.Query<Restaurant>(sql, new { id }).FirstOrDefault();
    }

    public Restaurant Create(Restaurant data)
    {
      var sql = @"
        INSERT INTO restaurants(name, location, category)
        VALUES(@Name,@Location,@Category);
        SELECT LAST_INSERT_ID();
        ";
      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }

    public bool Edit(Restaurant data)
    {
      var sql = @"UPDATE restaurants SET 
        name = @Name,
        location = @Location,
        category = @Category
      WHERE id = @Id;";

      return _db.Execute(sql, data) == 1;
    }
    public bool Delete(int id)
    {
      var sql = @"DELETE FROM restaurants WHERE id = @id;";
      return _db.Execute(sql, new { id }) == 1;
    }








  }
}