namespace Domain.Entity
{
  public class Category : Timestamp
  {
    public string Name { get; set; }

    public List<Product> Products { get; set; }
  }
}