using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Repositories;

namespace GoodEats.Services
{
  public class ReviewsService
  {
    private readonly ReviewsRepo _rr;

    public ReviewsService(ReviewsRepo rr)
    {
      _rr = rr;
    }

    internal Review create(Review data)
    {
      return _rr.Create(data);
    }

    public List<Review> GetReviewsByRestaurantId(int id)
    {
      return _rr.GetAllReviewsByRestaurantId(id);
    }

    internal List<Review> GetReviewsByCreatorId(string id)
    {
      return _rr.GetAllReviewsByCreatorId(id);
    }
  }
}