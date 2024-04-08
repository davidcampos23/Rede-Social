using System.Collections;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace backend.Security;

public class HashAndSalt
{
    private readonly SHA256 _algoritimoHash;

    public HashAndSalt()
    {
        _algoritimoHash = SHA256.Create();
    }

    public string EncryptPassword(string password)
    {
        byte[] salt;

        using (var rng = RandomNumberGenerator.Create())
        {
            salt = new byte[16];
            rng.GetBytes(salt);
        }

        var hashWithSalt = $"{password}:{Convert.ToBase64String(salt)}";

        var passwordBytes = Encoding.Default.GetBytes(hashWithSalt);
        var hashedPassword = _algoritimoHash.ComputeHash(passwordBytes);

        return $"{Convert.ToHexString(hashedPassword)}:{Convert.ToBase64String(salt)}";
    }

    public bool passwordVerify(string passwordLogin, string passwordRegister)
    {
        string[] hashParts = passwordRegister.Split(":");
        
        byte[] loginWithSalt = Encoding.Default.GetBytes(passwordLogin+ ":" + hashParts[1]);
        byte[] loginComputed = _algoritimoHash.ComputeHash(loginWithSalt);

        return StructuralComparisons.StructuralEqualityComparer.Equals(Convert.ToHexString(loginComputed), hashParts[0]);   
    }   
}