namespace Application.Dto
{
  public class UserReadDto
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }

  public class UserCreateDto
  {
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }

  public class UserUpdateDto
  {
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public byte[]? Salt { get; set; }
  }

  public class UserCredentials
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }

  public class UserContactDetailsDto
  {
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
  }

  public class UserContactDetailsUpdateDto
  {
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? PhoneNumber { get; set; }
  }

  public class UserWithDetailsReadDto
  {
    public UserReadDto User { get; set; }
    public UserContactDetailsDto UserContactDetails { get; set; }
  }
}