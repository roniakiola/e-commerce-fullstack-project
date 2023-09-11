namespace Application.Dto
{
  public class ProductReadDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> Images { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
  }

  public class ProductCreateDto
  {
    public string Name { get; set; }
    public List<string> Images { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
  }

  public class ProductUpdateDto
  {
    public string? Name { get; set; }
    public List<string>? Images { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public Guid? CategoryId { get; set; }
  }
}