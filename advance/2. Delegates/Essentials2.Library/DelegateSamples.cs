using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
	public static class DelegateSamples
	{
		public static event Del SomethingHappened;

		public delegate void Del(string inp);

		public static void PassMeWork(Del lol)
		{
			lol("delegates");
		}
		public static void DoSomething()
		{
			Console.WriteLine("I'm about to do something");
			if (SomethingHappened != null)
				SomethingHappened("I did something");
		}
	}
}
