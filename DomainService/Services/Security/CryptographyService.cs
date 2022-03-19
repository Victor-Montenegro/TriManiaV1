using System.Security.Cryptography;
using System.Text;

namespace DomainService.Services.Security
{
    public class CryptographyService
    {
        public static string GenerateEncryptionSHA512(string code)
        {
            HashAlgorithm hash = SHA512.Create();

            var encodedValue = Encoding.UTF8.GetBytes(code);
            var encrytedCode = hash.ComputeHash(encodedValue);

            var sb = new StringBuilder();

            foreach (var caracterer in encrytedCode)
                sb.Append(caracterer.ToString("X2"));

            return sb.ToString();
        }
    }
}
