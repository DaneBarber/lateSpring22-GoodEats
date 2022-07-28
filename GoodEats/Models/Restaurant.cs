using GoodEats.interfaces;

namespace GoodEats.Models
{

  public class Restaurant : IDBItem<int>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }

    public int AverageRating { get; set; }
    public int TotalReviews { get; set; }
  }

}