using System;

namespace FP.Common.EncryptionDecryption
{


	public enum StringEncodingType
	{
		/// <summary>
		/// Use hex byte encoding.
		/// </summary>
		Hex,
		/// <summary>
		/// Use Base64 byte encoding.
		/// </summary>
		Base64
	}
	/// <summary>
	/// Summary description for ICryptoHelper.
	/// </summary>
	public interface ICryptoHelper:IDisposable
	{
		
		/// <summary>
		/// The encryption key as a string.
		/// </summary>
		string Entropy
		{
			get;
			set;
		}

		/// <summary>
		/// The algorithm used by the helper.
		/// This property is read only.
		/// </summary>
		CryptographyAlgorithm Algorithm
		{
			get;
		}

		/// <summary>
		/// Encrypts the plaintext data.
		/// </summary>
		/// <param name="plaintext">The data to encrypt.</param>
		/// <returns>The byte array of the encrypted data.</returns>
		byte[] Encrypt(byte[] plaintext);

		/// <summary>
		/// Encrypts the plaintext string and returns a string of encoded bytes based on the encoding specified.
		/// </summary>
		/// <param name="plaintext">The data to encrypt.</param>
		/// <param name="encoding">The type of encoding to use for the return string.</param>
		/// <returns>A string of encoded bytes encoded with the specified encoding.</returns>
		string Encrypt(string plaintext, StringEncodingType encoding);
		
		/// <summary>
		/// Encrypts the plaintext string returning a Base64 encoded byte string.
		/// </summary>
		/// <param name="plaintext">The data to encrypt.</param>
		/// <returns>The encrypted plaintext as a Base64 encoded string.</returns>
		string Encrypt(string plaintext);
		

		/// <summary>
		/// Decrypts the cipherText
		/// </summary>
		/// <param name="cipherText">Data to decrypt</param>
		/// <returns>Byte array of the decrypted data</returns>	
		byte[] Decrypt(byte[] cipherText);

		/// <summary>
		/// Decrypts an encoded byte string using the encoding specified.
		/// </summary>
		/// <param name="cipherText">An encoded byte array of the ciphertext.</param>
		/// <param name="encoding">The specified encoding for the string ciphertext.</param>
		/// <returns>The plaintext string.</returns>
		string Decrypt(string cipherText, StringEncodingType encoding);

		/// <summary>
		/// Decrypts the Base64 encode byte string.
		/// </summary>
		/// <param name="cipherText">The Base64 encoded byte string to decrypt.</param>
		/// <returns>The plaintext string.</returns>
		string Decrypt(string cipherText);
	
	}
}
