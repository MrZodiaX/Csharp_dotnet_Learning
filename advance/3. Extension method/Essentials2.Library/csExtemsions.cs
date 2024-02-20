using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library.Extensions
{
	public static class extensionsClass
	{
		public static string Right(this string inp, int numChar)
		//using 'this' :modifier to indicate which type of method it operates on
		//(in parameter list of static method of static class)
		{
			if(string.IsNullOrEmpty(inp) || inp.Length<numChar)
			{
				return string.Empty;
			}

			return inp.Substring(inp.Length - numChar);
		}

		public static int Squared(this int num)
		{
			return num * num;
		}
	}
}
