using System;
using System.Security.Cryptography;
using System.Security;


namespace FP.Common.EncryptionDecryption
{
	/// <summary>
	/// The available symmetric encryption algortihms.
	/// </summary>

    public enum  CryptographyAlgorithm 
	{
		/// <summary>
		/// The DPAPI using the machine store.
		/// </summary>
		MachineDpApi,
		/// <summary>
		/// The DPAPI using the user store.
		/// </summary>
		UserDpApi,
		/// <summary>
		/// DES algorithm. This is no longer considered secure and should only be 
		/// used for backwards compatibility of if the data is short lived.
		/// </summary>
		Des,
		/// <summary>
		/// RC2 algorithm.
		/// </summary>
		Rc2,
		/// <summary>
		/// The Rijndael algorithm. This is the current AES algorithm.
		/// </summary>
		Rijndael, 
		/// <summary>
		/// The triple DES algorithm. This is the successor to the DES algorithm using a longer key length.
		/// </summary>
		TripleDes
	}

	/// <summary>
	/// Factory class for creating ICryptoHelper classes
	/// </summary>
	public sealed class CryptoFactory
	{
		/// <summary>
		/// Private constructor to prevent instantiation.
		/// </summary>
		private CryptoFactory(){}

		#region Public Create Methods

		/// <summary>
		/// Creates an ICryptoHelper based on the algorithm.
		/// </summary>
		/// <exception cref="CryptographicException" >Thrown if an invalid algorithm is provided.</exception>
		/// <param name="algorithm">The cryptographic algorithm to use.</param>
		/// <returns>The created ICryptoHelper.</returns>
		public static ICryptoHelper Create(CryptographyAlgorithm algorithm)
		{
			switch(algorithm)
			{
				case CryptographyAlgorithm.Des:
				case CryptographyAlgorithm.Rc2:
				case CryptographyAlgorithm.Rijndael:
				case CryptographyAlgorithm.TripleDes:
					return new SymmetricCryptographyHelper(algorithm);
				
				default:
				{
					throw new CryptographicException("Algorithm '" + 
						algorithm + 
						"' not supported.");
				}
			}
			
		}

		/// <summary>
		/// Creates an ICryptoHelper based on the algorithm using the supplied entropy.
		/// </summary>
		/// <exception cref="CryptographicException" >Thrown if an invalid algorithm is provided.</exception> 
		/// <param name="algorithm">The cryptographic algorithm to use.</param>
		/// <param name="entropy">The entropy to use for the encryption algorithm.</param>
		/// <returns>The created ICryptoHelper.</returns>
		public static ICryptoHelper Create(CryptographyAlgorithm algorithm, string entropy)
		{
			switch(algorithm)
			{
				case CryptographyAlgorithm.Des:
				case CryptographyAlgorithm.Rc2:
				case CryptographyAlgorithm.Rijndael:
				case CryptographyAlgorithm.TripleDes:
					return new SymmetricCryptographyHelper(algorithm, entropy);
				case CryptographyAlgorithm.MachineDpApi:
				case CryptographyAlgorithm.UserDpApi:
					//	return new DataProtector((Store)algorithm, entropy);
				default:
				{
					throw new CryptographicException("Algorithm '" + 
						algorithm + 
						"' not supported.");
				}
			}
		}

		/// <summary>
		/// Creates an ICryptoHelper based on the algorithm name using the supplied entropy.
		/// The algorithm name must match one of the name in the EncryptionAlgorithm enumeration.
		/// </summary>
		/// <param name="algorithmName">The name of the cryptographic algorithm to use.</param>
		/// <param name="entropy">The entropy to use for the encryption algorithm.</param>
		/// <returns>The created ICryptoHelper.</returns>
		public static ICryptoHelper Create(string algorithmName, string entropy)
		{
			CryptographyAlgorithm algorithm = (CryptographyAlgorithm)System.Enum.Parse(typeof(CryptographyAlgorithm), algorithmName, true);
			return Create(algorithm, entropy);
		}

		#endregion
	}
}
