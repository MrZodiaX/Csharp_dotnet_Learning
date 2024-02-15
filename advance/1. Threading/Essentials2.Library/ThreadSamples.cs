using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Essentials2.Library
{
    public static class ThreadSamples
    {
        public static void SimpleThread()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            Thread t = new Thread(DoFileWork);
            
            t.Start();
            Console.WriteLine("Work happening in main thread.");
            t.Join();  //waiting 
			Console.WriteLine("Done");
		}

        public static void DoFileWork()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"File access thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            string filePath = "..\\..\\..\\matt.json";
            //this could take a while
            var employeeJson = File.ReadAllText(filePath);
            var matt = JsonSerializer.Deserialize<Employee>(employeeJson);

            Console.WriteLine($"Employee read from file: {matt}");
        }



        public static async Task SimpleThreadAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Main thread id : {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            //await DoFileWorkAsync("Matt");
            //await : wait till DoFileWork is done

            try
            {
                Task matt = DoFileWorkAsync("Matt");
                Task shan = DoFileWorkAsync("Shan");

                Console.WriteLine("Work happening in main thread asynchoronously");

                //await Task.WhenAll(matt, shan); 
                //Task.WhenAll(matt, shan);  //without await, program continues without waiting for above task
                Task.WaitAll(matt, shan);
            }
            catch (AggregateException aex)
            {
                aex.Handle((inner) => inner is JsonException);
                Console.WriteLine("Exp : " + aex);
            }
			/*
            AggregateException :  can be caught and provide details about multiple exceptions, 
            possibly from different task executions.
            AggregateException is often returned from awaited code in the Task model 
            as it can represent multiple exceptions that possibly happened in different tasks.
            */
			Console.WriteLine("Work Done");
        }

        public static async Task DoFileWorkAsync(string empName)
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine($"File acces thread id : {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

			string filePath = $"..\\..\\..\\{empName}.json";
			//thread id wont change till below await in this case 
            //creata another thread if required 
			var employeeJson = await File.ReadAllTextAsync(filePath);
			var matt = JsonSerializer.Deserialize<Employee>(employeeJson);

			Console.WriteLine($"Employee read from file: {matt}");
		}
	}
}


/*
 
Task.WaitAll
- synchronous/blocking
- blocks current thread untill all provided tasks are completed 
- Exception : if any task throw exp, propagated immediately, remaining 
  task wont be executed 


Task.WhenAll
- Asynchronous/Non-Blocking 
- returns task that represents completion of all provided tasks 
- Exception: wont be propagated immediately, returned task will be faulted 
 
 */