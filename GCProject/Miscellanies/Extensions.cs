using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCProject.Miscellanies
{
	static class Extensions
	{
		public static string GetBytesAsString(this byte[] buffer)
		{
			return Encoding.UTF8.GetString(buffer);
		}
	}
}
