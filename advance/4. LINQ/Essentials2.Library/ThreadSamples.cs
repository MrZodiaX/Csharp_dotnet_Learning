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
            t.Join();
            Console.WriteLine("Work happening in main thread.");

            Console.WriteLine("After all done");
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

        //File.BeginReadAllText(filePath, EndReadingFile, state);

        //public void EndReadingFile(object state, IAsyncResult iar){
        //handle the completion of file reading
        //}

        public static async Task SimpleThreadAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            try
            {
                Task tMatt = DoFileWorkAsync("matt");
                Task tFelicia = DoFileWorkAsync("felician");

                Console.WriteLine("Work happening in main thread.");

                Task.WaitAll(tMatt, tFelicia);
            }
            catch(AggregateException aex)
            {
                aex.Handle((inner) =>
                {
                    Console.WriteLine(inner.Message);
                    return inner is JsonException;
                });

                Console.WriteLine(aex.Message);
            }
            //THIS IS where the callback code happens
            //FOLLOW UP: swith back to await the two method calls
            //and catch the appropriate exceptions

        }

        public static async Task DoFileWorkAsync(string employeeName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"File access thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            string filePath = $"..\\..\\..\\{employeeName}.json";
            var employeeJson = await File.ReadAllTextAsync(filePath);

            var matt = JsonSerializer.Deserialize<Employee>(employeeJson);

            Console.WriteLine($"Employee read from file: {matt}");
        }
    }
}
