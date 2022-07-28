using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {

    private readonly ReviewsService _reviewsService;
    private readonly AccountService _acctServ;

    public ProfilesController(ReviewsService reviewsService, AccountService acctServ)
    {
      _reviewsService = reviewsService;
      _acctServ = acctServ;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> getById(string id)
    {
      try
      {
        Profile profile = _acctServ.GetProfileById(id);
        return Ok(profile);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}/reviews")]
    public ActionResult<List<Review>> Get(string id)
    {
      try
      {
        List<Review> reviews = _reviewsService.GetReviewsByCreatorId(id);
        return Ok(reviews);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}