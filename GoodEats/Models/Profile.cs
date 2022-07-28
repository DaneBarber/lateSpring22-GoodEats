using GoodEats.interfaces;

namespace GoodEats.Models
{
  public class Profile : IDBItem<string>
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
  }
}