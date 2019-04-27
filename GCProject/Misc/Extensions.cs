using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCProject.Miscellanies
{
	static class Extensions
	{
		/// <summary>
		/// Client utility to get the string value of a bytes buffer
		/// </summary>
		/// <param name="buffer">bytes array buffer</param>
		/// <returns>string value</returns>
		public static string GetBytesAsString(this byte[] buffer)
		{
			return Encoding.UTF8.GetString(buffer);
		}

		/// <summary>
		/// Client utility to get the bytes array value of a json string
		/// </summary>
		/// <param name="jsonString">the json string message</param>
		/// <returns>the bytes array</returns>
		public static byte[] GetStringAsBytes(this string jsonString)
		{
			return Encoding.UTF8.GetBytes(jsonString);
		}
	}
}
