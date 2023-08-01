namespace Domain.Entity
{
  public class Order : Timestamp
  {
    public Guid UserId { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; }

    public User User { get; set; }

    public List<OrderItem> OrderItems { get; set; }
  }
}