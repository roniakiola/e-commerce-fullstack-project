namespace Domain.Entity
{
  public class User : Timestamp
  {
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }

    public UserContactDetails? UserContactDetails { get; set; }
    public Cart? Cart { get; set; }
    public List<Order>? Orders { get; set; }

    public enum UserRole
    {
      Admin,
      Customer
    }

  }
}