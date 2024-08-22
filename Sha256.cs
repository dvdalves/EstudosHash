using System.Security.Cryptography;
using System.Text;

namespace EstudosHash;

public class Sha256
{
    public static string GetHash(string input)
    {
        var hash = new StringBuilder();

        using (var sha256Hash = SHA256.Create())
        {
            var crypto = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
        }

        string hashString = hash.ToString();
        Console.WriteLine("Hash: {0}", hashString);

        return hashString;
    }
}