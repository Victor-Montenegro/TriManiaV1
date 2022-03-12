using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Security
{
    public static class Cryptography
    {
        public static string GenerateEncryptionSHA512(string code)
        {
            HashAlgorithm hash = SHA512.Create();

            string codeWithSecret = string.Concat(code,Settings.Secret);

            var encodedValue = Encoding.UTF8.GetBytes(codeWithSecret);
            var encrytedCode = hash.ComputeHash(encodedValue);

            var sb = new StringBuilder();

            foreach (var caracterer in encrytedCode)
                sb.Append(caracterer.ToString("X2"));

            return sb.ToString();
        }
    }
}
