using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace SoftwareTestOgSikkerhed.Codes
{
	public class AsymetricEncryptionService
	{
		private string _privateKey;
		private string _publicKey;
		private string _privateKeyFilePath = "privateKey.xml";
		private string _publicKeyFilePath = "publicKey.xml";

		private readonly HttpClient _httpClient;

		public AsymetricEncryptionService(HttpClient httpClient)
		{
			_httpClient = httpClient;

			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				//Check if Key file Exist before create new file
				//File.Create()
				if (File.Exists(_privateKeyFilePath) && File.Exists(_publicKeyFilePath))
				{
					XElement privateXmlFile = XElement.Load(_privateKeyFilePath);
					XElement publicXmlFile = XElement.Load(_publicKeyFilePath);

					_privateKey = privateXmlFile.Element("PrivateKey")?.Value;
					_publicKey = publicXmlFile.Element("PublicKey")?.Value;
				}
				else
				{
					_privateKey = rsa.ToXmlString(true);
					_publicKey = rsa.ToXmlString(false);

					XElement privateXmlFile = new XElement("Root",
						new XElement("PrivateKey", _privateKey)

						);
					XElement publicXmlFile = new XElement("Root",
						new XElement("PublicKey", _publicKey)

						);
					privateXmlFile.Save(_privateKeyFilePath);
					publicXmlFile.Save(_publicKeyFilePath);
				}
			}
		}

		//public async Task<string> AsymetricEncrypt(string textToEncrypt)
		//{
		//	string[] param = new string[] { textToEncrypt, _publicKey };
		//	string SerializeObject = JsonConvert.SerializeObject(param);
		//	StringContent content = new StringContent(SerializeObject, System.Text.Encoding.UTF8, "application/json");


		//	var encryptedValue = await _httpClient.PostAsync("https://localhost:7260/api/Encrypter", content);
		//	string encryptedValueAsString = encryptedValue.Content.ReadAsStringAsync().Result;
		//	return encryptedValueAsString;
		//}

		public async Task<string> AsymetricEncrypt(string textToEncrypt)
		{
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.FromXmlString(_publicKey);
				byte[] byteArrayTextToEncrypt = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
				byte[] encryptedDataAsByteArray = rsa.Encrypt(byteArrayTextToEncrypt, true);
				var encryptedDataAsString = Convert.ToBase64String(encryptedDataAsByteArray);

				return encryptedDataAsString;
			}
		}

		public string AsymetricDecrypt(string textToDecrypt)
		{
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.FromXmlString(_privateKey);

				byte[] byteArrayTextToDecrypt = Convert.FromBase64String(textToDecrypt);
				byte[] decryptValue = rsa.Decrypt(byteArrayTextToDecrypt, true);
				string decryptedValueAsString = System.Text.Encoding.UTF8.GetString(decryptValue);

				return decryptedValueAsString;
			}
		}
	}
}
