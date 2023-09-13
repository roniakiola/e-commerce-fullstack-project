namespace Application.Dto
{
  public class CategoryReadDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
  }

  public class CategoryCreateDto
  {
    public string Name { get; set; }
  }

  public class CategoryUpdateDto
  {
    public string Name { get; set; }
  }
}