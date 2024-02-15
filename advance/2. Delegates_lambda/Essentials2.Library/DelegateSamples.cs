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
		public delegate void Del(string inp);

        public static event Del SomethingHappened;  //event 


        public static void PassMeWork(Del lol)
		{
			lol("delegates from PassMeWork");
		}

		public static void DoSomething()  //raise or invoke event 
		{
			Console.WriteLine("__Event Triggered__");
			if (SomethingHappened != null)
				SomethingHappened("calling subscribers ");
		}


		//way 2 using Action : no need to declare your own delegates 
		public static event Action<string> something2;

		public static void PassMeWork2(Action<string> work)
		{
			work("delegates from PassMeWork_2");
		}

        public static void PassMeLogic(Func<string, int> worker)
        {
			int count = worker("Hello worker");
			Console.WriteLine($"Function return len : {count}");
        }

        /*
		Action, Func : They keep you from having to create unique delegates for common method signatures.
		The use of generics means that Action<T>, Func<T>, and their derivatives can be used
		in place of having to repeatedly define delegates that often have the same signature.

		*/


        //EXERCISE 
        public static int FindLargest(int[] arr, Func<int[], int> maxNumFun)  //input array, Func takes 1 array argument, return int value
		{
			int largest = maxNumFun(arr);
			return largest;
		}

    }
}
