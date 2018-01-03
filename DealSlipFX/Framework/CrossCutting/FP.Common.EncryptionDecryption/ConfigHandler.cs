using System;
using System.Security;
using System.Collections;
using System.Configuration;
using System.Security.Cryptography;
using FP.Common.Configuration;
using System.Web;
//using FP.Common.

namespace FP.Common.EncryptionDecryption
{
	/// <summary>
	/// 
	/// </summary>
	public class ConfigHandler : IDisposable
	{
		private ICryptoHelper helper ;			

		public ICryptoHelper Cryptohelper
		{
			get
			{
				return helper;
			}
		}

		public ConfigHandler(ICryptoHelper helper)
		{
			this.helper=helper;
		}

		public ConfigHandler()
		{
            FPCommon oGspCommon = new FPCommon();
            oGspCommon = (FPCommon)System.Configuration.ConfigurationManager.GetSection("GSPCommon");
            //string sEncryptionDecryptionAlgorithm = oGspCommon.CommonSettings.EncryptionDecryptionAlgorithm.ToString().ToUpper();
            CryptographyAlgorithm algorithm = new CryptographyAlgorithm();
              /*  switch (sEncryptionDecryptionAlgorithm)
						{
							case "DES":
								algorithm = CryptographyAlgorithm.Des;
								break;
							case "MACHINEDPAPI":
								algorithm = CryptographyAlgorithm.MachineDpApi;
								break;
							case "RC2":
								algorithm = CryptographyAlgorithm.Rc2;
								break;
							case "RIJNDAEL":
								algorithm = CryptographyAlgorithm.Rijndael;
								break;
							case "TRIPLEDES":
								algorithm = CryptographyAlgorithm.TripleDes;
								break;
							case "USERDPAPI":
								algorithm = CryptographyAlgorithm.UserDpApi;
								break;
						}*/
			CreateHelper(algorithm);
		}

        public ConfigHandler(string algorithm, string key)
        {
            switch (algorithm.ToUpper())
            {
                case "TRIPLEDES":
                    CreateHelper(CryptographyAlgorithm.TripleDes, key);
                    break;
                case "MACHINEDPAPI":
                    CreateHelper(CryptographyAlgorithm.MachineDpApi, key);
                    break;
                case "USERDPAPI":
                    CreateHelper(CryptographyAlgorithm.UserDpApi, key);
                    break;
                case "DES":
                    CreateHelper(CryptographyAlgorithm.Des, key);
                    break;
                case "RC2":
                    CreateHelper(CryptographyAlgorithm.Rc2, key);
                    break;
                case "RIJNDAEL":
                    CreateHelper(CryptographyAlgorithm.Rijndael, key);
                    break;
            }
        }

		#region IDisposable members
		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			helper.Dispose();

		}
		#endregion
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetKey()
		{	
			return helper.Entropy;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="algorithm"></param>
		private void CreateHelper(CryptographyAlgorithm algorithm)
		{
			helper=CryptoFactory.Create(algorithm);
		}

        private void CreateHelper(CryptographyAlgorithm algorithm, string key)
        {
            if (key.Trim().Length == 0)
                helper = CryptoFactory.Create(algorithm);
            else
            {
                helper = CryptoFactory.Create(algorithm, key);
            }
        }
			  
	}
}
