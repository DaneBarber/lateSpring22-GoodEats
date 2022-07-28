using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class ProfileController : ControllerBase
  {

    private readonly ReviewsService _reviewsService;

    public ProfileController(ReviewsService reviewsService)
    {
      _reviewsService = reviewsService;
    }

    [HttpGet("reviews")]
    public async Task<ActionResult<List<Review>>> Get()
    {
      try
      {
        var user = await HttpContext.GetUserInfoAsync<Account>();
        List<Review> reviews = _reviewsService.GetReviewsByCreatorId(user?.Id);
        return Ok(reviews);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}