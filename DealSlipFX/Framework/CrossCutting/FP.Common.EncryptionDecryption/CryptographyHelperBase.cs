using System;

namespace FP.Common.EncryptionDecryption
{
	/// <summary>
	/// A helper class to encapsulte encryption and 
	/// decryption using a symmetric algorithm.
	/// </summary>
	internal abstract class CryptographyHelperBase : ICryptoHelper
	{
				
		#region ICryptoHelper Members

		/// <summary>
		/// Performs the encryption using the specified encryption algorithm.
		/// </summary>
		/// <param name="plaintext">The data to encrypt as a byte array.</param>
		/// <returns>The encrypte data as a byte array.</returns>
		public abstract byte[] Encrypt(byte[] plaintext);

		/// <summary>
		/// Encrypts the plaintext returning an encoded bytes array in the specified encoding.
		/// </summary>
		/// <param name="plaintext">The plaintext data to encrypt.</param>
		/// <param name="encoding">The encoding to use for the return string.</param>
		/// <returns>An encoded string of the encrypted data.</returns>
		public string Encrypt( string plaintext, StringEncodingType encoding )
		{
			byte [] bytesIn = ByteEncoding.StringToBytes(plaintext);
			byte [] encryptedBytes = Encrypt(bytesIn);
			string returnValue = null;
			switch(encoding)
			{
				case StringEncodingType.Base64:
					returnValue = ByteEncoding.BytesToBase64(encryptedBytes);
					break;
				case StringEncodingType.Hex:
					returnValue = ByteEncoding.BytesToHex(encryptedBytes);
					break;
				default:
					throw new ArgumentException("Unknown encoding type.");
			}
			Array.Clear(bytesIn, 0, bytesIn.Length);
			Array.Clear(encryptedBytes, 0, encryptedBytes.Length);
			return returnValue;
		}

		/// <summary>
		/// Encrypts the plaintext string returning a Base64 encoded byte string.
		/// </summary>
		/// <param name="plaintext">The data to encrypt.</param>
		/// <returns>The encrypted plaintext as a Base64 encoded string.</returns>
		public string Encrypt( string plaintext)
		{
			return Encrypt(plaintext, StringEncodingType.Base64);
		}


		/// <summary>
		/// Decrypts the ciphertext.
		/// </summary>
		/// <param name="cipherText">The encrypted data to decrypt as a byte array.</param>
		/// <returns>The decrypted data as a byte array.</returns>
		public abstract byte[] Decrypt(byte[] cipherText);
		

		/// <summary>
		/// Performs the decryption using the specified encoding.
		/// </summary>
		/// <param name="cipherText">The encrypted data as an encoded string.</param>
		/// <param name="encoding">The encoding used for the string.</param>
		/// <returns>The plaintext string.</returns>
		public string Decrypt( string cipherText, StringEncodingType encoding )
		{
			byte[] bytesIn = null;
			switch(encoding)
			{
				case StringEncodingType.Base64:
					bytesIn = ByteEncoding.Base64ToBytes(cipherText);
					break;
				case StringEncodingType.Hex:
					bytesIn = ByteEncoding.HexToBytes(cipherText);
					break;
				default:
					throw new ArgumentException("Unknown encoding type.");
			}
			byte[] bytesOut = Decrypt(bytesIn);
			string returnValue = ByteEncoding.BytesToString(bytesOut);
			Array.Clear(bytesIn, 0, bytesIn.Length);
			Array.Clear(bytesOut, 0, bytesOut.Length);
			return returnValue;
		}

		/// <summary>
		/// Decrypts the Base64 encode byte string.
		/// </summary>
		/// <param name="cipherText">The Base64 encoded byte string to decrypt.</param>
		/// <returns>The plaintext string.</returns>
		public string Decrypt( string cipherText)
		{
			return Decrypt(cipherText, StringEncodingType.Base64);
		}


		#endregion

		#region IDisposable Members

		public abstract void Dispose();

		#endregion

		#region ICryptoHelper Properties

		public abstract string Entropy
		{
			get;
			set;
		}

		public abstract CryptographyAlgorithm Algorithm
		{
			get;
		}
		#endregion
	}

}
		