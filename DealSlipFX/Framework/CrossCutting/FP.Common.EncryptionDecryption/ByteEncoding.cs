using System;
using System.Text;
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
//               
//-----------------------------------------------------------------------------

namespace FP.Common.EncryptionDecryption
{
	/// <summary>
	/// Helper class to encode bytes, convert strings to and from bytes and bytes to and from strings.
	/// </summary>
	public sealed class ByteEncoding
	{
		/// <summary>
		/// Private constructor to prevent instantiation.
		/// </summary>
		private ByteEncoding()
		{
        }

		#region Hex

		/// <summary>
		/// Gets the number of bytes that a hexadecimal encoded string contains.
		/// Removes all non A-F, 0-9, characters
		/// </summary>
		/// <param name="hexString">The hexadecimal encoded string.</param>
		/// <returns>A count of the number of bytes.</returns>
		private static int GetByteCount(string hexString)
		{
			int numHexChars = 0;
			
			// remove all non A-F, 0-9, characters
			for (int i=0; i < hexString.Length; i++)
			{
				char c = hexString[i];
                if (IsHexDigit(c))
                {
                   numHexChars++;
                }
			}
			
			return (numHexChars / 2); // 2 characters per byte
		}

		/// <summary>
		/// Creates a byte array from the hexadecimal string. Each two characters are combined
		/// to create one byte. Non-hexadecimal characters are ignored. 
		/// </summary>
		/// <param name="hexString">The hexadecimal String to convert to byte array.</param>
		/// <returns>The converted hexadecimal string.</returns>
		public static byte[] HexToBytes(string hexString)
		{
			int discarded;
			return HexToBytes(hexString, out discarded);
		}

		/// <summary>
		/// Creates a byte array from the hexadecimal string. Each two characters are combined
		/// to create one byte. Non-hexadecimal characters are ignored. 
		/// </summary>
		/// <param name="hexString">The hexadecimal String to convert to byte array.</param>
		/// <param name="discarded">The number of non-hexadecimal characters in the string.</param>
		/// <returns>The converted hexadecimal string.</returns>
		public static byte[] HexToBytes(string hexString, out int discarded)
		{
			discarded = 0;
			StringBuilder newString = new StringBuilder(hexString.Length);
			char c;
			// remove all none A-F, 0-9, characters
			for (int i=0; i < hexString.Length; i++)
			{
				c = hexString[i];
                if (IsHexDigit(c))
                {
                    newString.Append(c);
                }
                else
                {
                    discarded++;
                }
			}
			// if odd number of characters, discard last character
			if (newString.Length % 2 != 0)
			{
				discarded++;
				newString = newString.Remove(newString.Length-1, 1);
			}

			int byteLength = newString.Length / 2;
			byte[] bytes = new byte[byteLength];
			for (int i=0, j = 0; i < byteLength; i++, j+=2)
			{
				string hex = new String(new Char[] {newString[j], newString[j+1]});
				bytes[i] = HexToByte(hex);
			}

			return bytes;
		}


		/// <summary>
		/// Converts an byte array to a hexadecimal encoded string.
		/// </summary>
		/// <param name="bytes">The byte array to convert.</param>
		/// <returns>The hexadecimal encoded bytes.</returns>
		public static string BytesToHex(byte[] bytes)
		{
			StringBuilder hexString = new StringBuilder(bytes.Length);
			for (int i=0; i < bytes.Length; i++)
			{
				hexString.Append(bytes[i].ToString("X2"));
			}
			return hexString.ToString();
		}


		/// <summary>
		/// Determines if given string is in proper hexadecimal string format
		/// </summary>
		/// <param name="hexString">The string to test.</param>
		/// <returns>True if the string is in heaxadecimal format, false if not.</returns>
		public static bool InHexFormat(string hexString)
		{
			foreach (char digit in hexString)
			{
				if (!IsHexDigit(digit))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Returns true the char is a hexadecimal digit (A-F, a-f, 0-9)
		/// </summary>
		/// <param name="c">Character to test</param>
		/// <returns>True if hex digit, false if not.</returns>
		public static bool IsHexDigit(Char c)
		{
			int numA = Convert.ToInt32('A');
			int num1 = Convert.ToInt32('0');
			c = Char.ToUpper(c);
			int numChar = Convert.ToInt32(c);
			if (numChar >= numA && numChar < (numA + 6)
				|| numChar >= num1 && numChar < (num1 + 10))
				return true;
			return false;
		}
		/// <summary>
		/// Converts 1 or 2 character string into equivalant byte value.
		/// </summary>
		/// <param name="hex">1 or 2 character string.</param>
		/// <returns>A byte.</returns>
		private static byte HexToByte(string hex)
		{
            if (hex.Length > 2 || hex.Length <= 0)
            {
               throw new ArgumentException("hex must be 1 or 2 characters in length");
            }
			return byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
		}

		#endregion

		#region Base64

		/// <summary>
		/// Converst a byte array to a Base64 encoded string.
		/// </summary>
		/// <param name="bytes">The byte array to convert.</param>
		/// <returns>The Base64 encoded bytes.</returns>
		public static string BytesToBase64(byte[] bytes)
		{
			return Convert.ToBase64String(bytes);
		}

		/// <summary>
		/// Convers a Base64 encoded string to a byte array.
		/// </summary>
		/// <param name="b64String">The Base64 string to convert.</param>
		/// <returns>The bytes represented by the Base64 string.</returns>
		public static byte[] Base64ToBytes( string b64String)
		{
			return Convert.FromBase64String(b64String);
		}

		#endregion

		#region String

		/// <summary>
		/// Converts a byte array to a unicode string.
		/// </summary>
		/// <param name="bytes">The byte array to convert.</param>
		/// <returns>The string representation of the bytes.</returns>
		public static string BytesToString(byte[] bytes)
		{
			return Encoding.Unicode.GetString(bytes);
		}

		/// <summary>
		/// Converts a unicode string to a byte array.
		/// </summary>
		/// <param name="data">The string to convert.</param>
		/// <returns>The byte values of the string's characters.</returns>
		public static byte[] StringToBytes(string data)
		{
			return System.Text.Encoding.Unicode.GetBytes(data);
		}

		#endregion


	}
}
