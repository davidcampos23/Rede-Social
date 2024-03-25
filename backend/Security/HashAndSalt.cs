using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace backend.Security;

public class HashAndSalt
{
    private SHA256 _algoritimoHash;

    public HashAndSalt()
    {
        _algoritimoHash = SHA256.Create();
    }

    public string EncryptPassword(string password)
    {
        byte[] salt;

        using(var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt = new byte[16]);
        }

        byte[] passwordWithSalt = new byte[password.Length + salt.Length];
        Array.Copy(Encoding.UTF8.GetBytes(password), passwordWithSalt, password.Length);
        Array.Copy(salt, 0, passwordWithSalt, password.Length, salt.Length);

        byte[] encryptedPassword = _algoritimoHash.ComputeHash(passwordWithSalt);

        var sb = new StringBuilder();
        foreach(var caracter in encryptedPassword)
        {
            sb.Append(caracter.ToString("x2"));
        }

        return $"{sb.ToString()}:{Convert.ToBase64String(salt)}";
    }
}