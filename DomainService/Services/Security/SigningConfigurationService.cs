using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace DomainService.Services.Security
{
    public class SigningConfigurationService
    {
        public SecurityKey Key { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurationService()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
