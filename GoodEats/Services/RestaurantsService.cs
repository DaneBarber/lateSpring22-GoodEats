using System;
using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Repositories;

namespace GoodEats.Services
{
  public class RestaurantsService
  {

    private readonly RestaurantsRepo _rr;

    public RestaurantsService(RestaurantsRepo rr)
    {
      _rr = rr;
    }

    public List<Restaurant> Get()
    {
      return _rr.Get();
    }

    internal Restaurant Get(int id)
    {
      return _rr.Get(id);
    }

    internal Restaurant Create(Restaurant restaurantData)
    {
      return _rr.Create(restaurantData);
    }

    internal Restaurant Edit(Restaurant restaurantData)
    {
      return _rr.Edit(restaurantData) ? restaurantData : throw new Exception("Unable to Update because ughhhh");
    }

    internal void Delete(int id)
    {
      _rr.Delete(id);
    }
  }
}