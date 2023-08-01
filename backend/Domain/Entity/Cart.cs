namespace Domain.Entity
{
  public class Cart : Timestamp
  {
    public Guid UserId { get; set; }
    public decimal Total { get; set; }
    public DateOnly ExpiresAt { get; set; }

    public User User { get; set; }

    public List<CartItem> CartItems { get; set; }


  }
}