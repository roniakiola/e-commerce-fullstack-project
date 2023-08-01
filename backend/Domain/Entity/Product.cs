namespace Domain.Entity
{
  public class Product : BaseEntity
  {
    public string Name { get; set; }
    public List<string> Images { get; set; }
    public string Description { get; set; }
    public string DescriptionLong { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; }

  }
}