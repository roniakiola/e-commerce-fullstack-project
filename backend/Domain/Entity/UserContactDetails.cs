namespace Domain.Entity
{
  public class UserContactDetails : BaseEntity
  {
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
  }
}