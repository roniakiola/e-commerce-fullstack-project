namespace Domain.Entity
{
  public class OrderItem : BaseEntity
  {
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
  }
}