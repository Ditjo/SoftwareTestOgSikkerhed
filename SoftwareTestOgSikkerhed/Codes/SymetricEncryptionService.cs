using Microsoft.AspNetCore.DataProtection;

namespace SoftwareTestOgSikkerhed.Codes
{
    public class SymetricEncryptionService
    {
        private readonly IDataProtector _dataProtector;

        public SymetricEncryptionService(IDataProtectionProvider protector)
        {
            _dataProtector = protector.CreateProtector("Mads");
        }

        public string Protect(string textToEncrypt)
        {
            return _dataProtector.Protect(textToEncrypt);
        }

        public string UnProtect(string textToDecrypt)
        {
            return _dataProtector?.Unprotect(textToDecrypt);
        }
    }
}
