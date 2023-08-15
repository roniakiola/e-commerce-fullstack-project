namespace Domain.Entity
{
  public class Timestamp : BaseEntity
  {
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
  }
}