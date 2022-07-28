using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReviewsController : ControllerBase
  {

    private readonly ReviewsService _reviewsService;

    public ReviewsController(ReviewsService reviewsService)
    {
      _reviewsService = reviewsService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Review>> Create([FromBody] Review data)
    {
      try
      {
        var user = await HttpContext.GetUserInfoAsync<Account>();
        data.CreatorId = user?.Id;
        Review review = _reviewsService.create(data);
        return Ok(review);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}