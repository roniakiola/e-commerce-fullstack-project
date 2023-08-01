namespace Domain.Entity
{
  public class Timestamp : BaseEntity
  {
    public DateOnly CreatedAt { get; set; }
    public DateOnly ModifiedAt { get; set; }
  }
}