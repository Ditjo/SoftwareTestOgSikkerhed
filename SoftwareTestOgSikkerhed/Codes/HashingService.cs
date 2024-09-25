using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;

namespace SoftwareTestOgSikkerhed.Codes
{
    public class HashingService
    {
        //DO NOT USE !!!!!!!!!
        public string MD5Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            MD5 md5 = MD5.Create();
            byte[] hashedValue = md5.ComputeHash(inputByte);
            //We return to string so we have something to look at
            return Convert.ToBase64String(hashedValue);
        }

        public string SHA256Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            SHA256 sha256 = SHA256.Create();
            byte[] hashedValue = sha256.ComputeHash(inputByte);
            //We return to string so we have something to look at
            return Convert.ToBase64String(hashedValue);
        }

        public string HMACHashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            byte[] myKey = Encoding.ASCII.GetBytes("Mads");

            HMACSHA256 hmacsha256 = new HMACSHA256();

            hmacsha256.Key = myKey;
            byte[] hashedValue = hmacsha256.ComputeHash(inputByte);

            //We return to string so we have something to look at
            return Convert.ToBase64String(hashedValue);
        }

        public string PBKDF2Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            byte[] saltAsByteArray = Encoding.ASCII.GetBytes("MySalt");

            var hashAlgo = new System.Security.Cryptography.HashAlgorithmName("SHA256");
            byte[] hashedValue = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(inputByte, saltAsByteArray, 11, hashAlgo, 32);

            return Convert.ToBase64String(hashedValue);
        }


        //BCrypt is a Nuget Bcrypt.net - Next
        public string BCryptHashing(string textToHash)
        {
            //1. Hash
            //return BCrypt.Net.BCrypt.HashPassword(textToHash);

            //2. Hash
            //int workFactor = 11;
            //string salt = BCrypt.Net.BCrypt.GenerateSalt();
            //bool entropy = true;
            //return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, entropy);

            //3. Hash
            int workFactor = 11;
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            bool entropy = true;
            HashType hashType = HashType.SHA256;
            return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, entropy, hashType);
        }

        public bool VerifyBCryptHashing(string textToHash, string hashedValueFromDB)
        {
            //1. Hash
            //return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDB);

            //2. Hash
            //return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDB, true);

            //3. Hash
            return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDB, true, BCrypt.Net.HashType.SHA256);
        }

    }
}
