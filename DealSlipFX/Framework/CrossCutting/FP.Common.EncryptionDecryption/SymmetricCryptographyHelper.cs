using System;
using System.Security.Cryptography;
using System.IO;

//-----------------------------------------------------------------------------
//
//
//
//
//
//
//
//
//
//               
//-----------------------------------------------------------------------------

namespace FP.Common.EncryptionDecryption
{
	
	/// <summary>
	/// A helper class to encapsulate encryption and 
	/// decryption using a symmetric algorithm.
	/// </summary>
	internal class SymmetricCryptographyHelper : CryptographyHelperBase
	{

		#region Private Fields

		protected CryptographyAlgorithm algorithmId; // The encryption type to use
		protected string entropy;					// The password to use to create the encryption 
		private SymmetricAlgorithm algorithm;	// The encryption provider
		private int keyLength;					// the size of the key to use for encryption

		#endregion

		#region Properties

		/// <summary>
		/// Read only value of the encryption type to use.
		/// </summary>
		public override CryptographyAlgorithm Algorithm
		{
			get{ return algorithmId;}
		}

		/// <summary>
		/// The encryption/decryption password used to creqte the encryption key.
		/// </summary>
		public override string Entropy
		{
			get
			{
				return entropy;
			}
			set
			{
				entropy = value;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Overloaded constructor.
		/// </summary>
		/// <param name="algId">The type of algorithm to use.</param>
		public SymmetricCryptographyHelper(CryptographyAlgorithm algId)
		{
			algorithmId = algId;
		}

		/// <summary>
		/// Overloaded Constructor
		/// </summary>
		/// <param name="algId">The type of algorithm to use.</param>
		/// <param name="password">Password to use to create the encryption key</param>
		public SymmetricCryptographyHelper(CryptographyAlgorithm algId, string password)
		{
			algorithmId = algId;
			entropy = password;
		}

		#endregion

        #region ICryptoHelper Members

        /// <summary>
        /// Performs the encryption using the specified encryption algorithm.
        /// </summary>
        /// <param name="plaintext">The data to encrypt as a byte array.</param>
        /// <returns>The encrypte data as a byte array.</returns>
        public override byte[] Encrypt(byte[] plaintext)
        {
            if (algorithm == null)
            {
                GetCryptoAlgorithm();
            }

            using (MemoryStream dataStream = new MemoryStream())
            {
                byte[] salt = GetSalt();
                dataStream.Write(salt, 0, salt.Length);
                algorithm.GenerateIV();
                dataStream.Write(algorithm.IV, 0, algorithm.IV.Length);
                algorithm.Key = GetKey(salt);
                using (ICryptoTransform transform = algorithm.CreateEncryptor())
                {
                    using (CryptoStream crypto =
                              new CryptoStream(dataStream, transform,
                              CryptoStreamMode.Write))
                    {
                        crypto.Write(plaintext, 0, plaintext.Length);
                        crypto.FlushFinalBlock();
                        dataStream.Flush();
                        byte[] encData = dataStream.ToArray();
                        crypto.Close();
                        return encData;
                    }
                }
            }
        }



        /// <summary>
        /// Decrypts the ciphertext.
        /// </summary>
        /// <param name="cipherText">The encrypted data to decrypt as a byte array.</param>
        /// <returns>The decrypted data as a byte array.</returns>
        public override byte[] Decrypt(byte[] cipherText)
        {
            if (algorithm == null)
            {
                GetCryptoAlgorithm();
            }

            using (MemoryStream dataStream = new MemoryStream(cipherText))
            {
                byte[] salt = new byte[16];
                byte[] iv = new byte[algorithm.IV.Length];
                dataStream.Read(salt, 0, salt.Length);
                dataStream.Read(iv, 0, iv.Length);
                algorithm.Key = GetKey(salt);
                algorithm.IV = iv;
                using (CryptoStream crypto =
                          new CryptoStream(dataStream, algorithm.CreateDecryptor(),
                          CryptoStreamMode.Read))
                {
                    byte[] buffer = new byte[256];
                    int bytesRead = 0;
                    using (MemoryStream decryptedData = new MemoryStream())
                    {
                        do
                        {
                            bytesRead = crypto.Read(buffer, 0, 256);
                            decryptedData.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead > 0);
                        crypto.Close();
                        byte[] decData = decryptedData.ToArray();
                        decryptedData.Close();
                        return decData;
                    }
                }
            }
        }


        #endregion

		#region Private Methods

		/// <summary>
		/// An internal factory that creates the cryptograhic provider based on the type 
		/// specified in the constructor.
		/// </summary>
		private void GetCryptoAlgorithm()
		{
				
			// Pick the provider.
			switch (algorithmId)
			{
				case CryptographyAlgorithm.Des:
				{
					algorithm = new DESCryptoServiceProvider();
					break;
				}
				case CryptographyAlgorithm.TripleDes:
				{
					algorithm = new TripleDESCryptoServiceProvider();
					break;
				}
				case CryptographyAlgorithm.Rc2:
				{
					algorithm = new RC2CryptoServiceProvider();
					break;
				}
				case CryptographyAlgorithm.Rijndael:
				{
					algorithm = new RijndaelManaged();
					break;
				} 
				default:
				{
					throw new CryptographicException("Algorithm Id '" + 
						algorithmId + 
						"' not supported.");
				}
			}

			//Set up the algorithm with a key.
			algorithm.Mode = CipherMode.CBC;

			keyLength = (algorithm.LegalKeySizes[0].MaxSize / 8);
		}

		/// <summary>
		/// Gets a 16 byte salt for creation of the encryption key.
		/// </summary>
		/// <returns>An array of 16 random bytes.</returns>
		private byte[] GetSalt()
		{
			return GetRandomBytes(16);
		}

		/// <summary>
		/// Generates an encryption key based on the salt and password.
		/// </summary>
		/// <param name="salt">An array of random bytes used in generating the key.</param>
		/// <returns>A byte array representing a cryptographic key.</returns>
		private byte[] GetKey(byte[] salt)
		{
			byte[] key;
			if(entropy == null || entropy.Trim().Length == 0)
			{
				entropy = GetEntropy(keyLength);
			}

			PasswordDeriveBytes passBytes = new PasswordDeriveBytes(entropy, salt);
			key = passBytes.GetBytes(keyLength);

            return key;
		}

		public static string GetEntropy(int length)
		{
			//return ByteEncoding.BytesToBase64(GetRandomBytes(length));
            return ByteEncoding.BytesToString(GetRandomBytes(length));
		}

		public static byte[] GetRandomBytes(int length)
		{
			RandomNumberGenerator randNumGen = RandomNumberGenerator.Create();
			byte[] entropy = new byte[length];
			randNumGen.GetBytes(entropy);
			return entropy;
		}
		


		#endregion

		#region IDisposable Members

		/// <summary>
		/// Release any unmanaged resources.
		/// </summary>
		public override void Dispose()
		{
			if( algorithm != null )
				algorithm.Clear();
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
	