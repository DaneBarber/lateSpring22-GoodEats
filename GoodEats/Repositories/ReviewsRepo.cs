using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GoodEats.Models;

namespace GoodEats.Repositories
{
  public class ReviewsRepo
  {

    private readonly IDbConnection _db;

    public ReviewsRepo(IDbConnection db)
    {
      _db = db;
    }


    public Review Get(int id)
    {
      var sql = "SELECT * FROM reviews WHERE id = @id";
      return _db.Query<Review>(sql, new { id }).FirstOrDefault();
    }

    public List<Review> GetAllReviewsByRestaurantId(int restaurantId)
    {
      var sql = @"
        SELECT r.*, a.* FROM reviews r 
        
        JOIN accounts a ON a.id = r.creatorId 
        
        WHERE restaurantId = @restaurantId";
      return _db.Query<Review, Profile, Review>(sql, (review, profile) =>
      {
        review.Creator = profile;
        return review;
      }, new { restaurantId }).ToList();

    }

    internal List<Review> GetAllReviewsByCreatorId(string creatorId)
    {
      var sql = @"
        SELECT r.*, a.*, res.* FROM reviews r 
        JOIN restaurants res ON res.id = r.restaurantId
        JOIN accounts a ON a.id = r.creatorId 
        
        WHERE creatorId = @creatorId";
      return _db.Query<Review, Profile, Restaurant, Review>(sql, (review, profile, res) =>
      {
        review.Creator = profile;
        review.Restaurant = res;
        return review;
      }, new { creatorId }).ToList();

    }

    public Review Create(Review data)
    {
      var sql = @"
      INSERT INTO reviews 
      (rating, body, creatorId, restaurantId)
      VALUES
      (@Rating, @Body, @CreatorId, @RestaurantId);
      SELECT LAST_INSERT_ID();";

      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }


    public Review FindAndDelete(int id)
    {
      var sql = "DELETE FROM reviews WHERE id = @id;";
      var review = Get(id);
      _db.Execute(sql, new { id });
      return review;
    }


  }
}