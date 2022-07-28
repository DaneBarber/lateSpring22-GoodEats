using System.ComponentModel.DataAnnotations;
using GoodEats.interfaces;

namespace GoodEats.Models
{
  public class Review : IDBItem<int>
  {
    public int Id { get; set; }

    public string Body { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }

    // TODO figure this out virtual property
    public Profile Creator { get; set; }
    public Restaurant Restaurant { get; set; }

    public int RestaurantId { get; set; }
    public string CreatorId { get; set; }
  }



}