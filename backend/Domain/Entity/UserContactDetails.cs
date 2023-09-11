namespace Domain.Entity
{
  public class UserContactDetails : Timestamp
  {
    public Guid UserId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }

    public User User { get; set; }
  }
}