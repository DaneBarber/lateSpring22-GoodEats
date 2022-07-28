using System;
using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RestaurantsController : ControllerBase
  {
    private readonly RestaurantsService _restaurantsService;
    private readonly ReviewsService _reviewService;

    public RestaurantsController(RestaurantsService rs, ReviewsService rrs)
    {
      _restaurantsService = rs;
      _reviewService = rrs;
    }

    [HttpGet]
    public ActionResult<List<Restaurant>> Get()
    {
      try
      {
        List<Restaurant> restaurants = _restaurantsService.Get();
        return Ok(restaurants);
      }
      catch (System.Exception Error)
      {
        return BadRequest(Error.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Restaurant> Get(int id)
    {
      try
      {
        Restaurant restaurant = _restaurantsService.Get(id);
        return Ok(restaurant);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{restaurantId}/reviews")]
    public ActionResult<List<Review>> GetReviews(int restaurantId)
    {
      try
      {
        List<Review> reviews = _reviewService.GetReviewsByRestaurantId(restaurantId);
        return Ok(reviews);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Restaurant> Create([FromBody] Restaurant restaurantData)
    {
      try
      {
        Restaurant restaurant = _restaurantsService.Create(restaurantData);
        // restaurant.CreatedAt = DateTime.UtcNow;
        // restaurant.UpdatedAt = DateTime.UtcNow;
        return Ok(restaurant);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Restaurant> Edit([FromBody] Restaurant restaurantData, int id)
    {
      try
      {
        restaurantData.Id = id;
        Restaurant restaurant = _restaurantsService.Edit(restaurantData);
        return Ok(restaurant);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Restaurant> Delete(int id)
    {
      try
      {
        _restaurantsService.Delete(id);
        return Ok("Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}