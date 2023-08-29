using System.Security.Cryptography;
using System.Text;

namespace Application.Service.Implementation.Shared
{
  public class PasswordService
  {
    public static void HashPassword(string originalPassword, out string hashedPassword, out byte[] salt)
    {
      var hmac = new HMACSHA256();
      salt = hmac.Key;
      hashedPassword = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(originalPassword)));
    }

    public static bool VerifyPassword(string originalPassword, string hashedPassword, byte[] salt)
    {
      var hmac = new HMACSHA256(salt);
      var hashedOriginal = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(originalPassword)));
      return hashedOriginal == hashedPassword;
    }
  }
}