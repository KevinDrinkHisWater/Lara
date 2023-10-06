using System;
using System.Linq;
using System.Text;

namespace TestProgrammation
{

	/// <summary>
	/// Generates a password.
	/// </summary>
	public class PasswordGenerator
	{

		/// <summary>
		/// Generates a password.
		/// </summary>
		/// <param name="charactersCount">The number of characters in the password</param>
		/// <param name="allowUpperCase">Defines whether upper cases caracters are allowed or not</param>
		/// <returns>The generated password</returns>
		public string Generate(int charactersCount, bool allowUpperCase)
		{
			string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789?$%_-;";
            if (!allowUpperCase)
            {
				chars = chars.Substring(26);
            }

			StringBuilder sb = new StringBuilder();
			Random random = new Random();

			char lastChar = '\0';
			for (int i = 0; i < charactersCount; i++)
			{
				char c;
				do
				{
					c = chars[random.Next(chars.Length)];
				} while (c == lastChar);

				sb.Append(c);
				lastChar = c;
			}

			return sb.ToString();
		}

	}

}