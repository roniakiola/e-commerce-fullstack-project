namespace Domain.Entity
{
  public class User : Timestamp
  {
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Role { get; set; }

    public UserContactDetails UserContactDetails { get; set; }
  }
}