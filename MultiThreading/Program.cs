using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tasks = new List<Task>();
            tasks.Add(Task.Run( () => DoSomethingVerySlow()));
            tasks.Add(Task.Run( () => DoSomethingVerySlow()));
            tasks.Add(Task.Run( () => DoSomethingVerySlow()));
            tasks.Add(Task.Run( () => DoSomethingVerySlow()));
            tasks.Add(Task.Run( () => DoSomethingVerySlow()));
            tasks.Add(Task.Run( () => DoSomethingVerySlow()));
            tasks.Add(Task.Run( () => DoSomethingVerySlow()));
            tasks.Add(Task.Run( () => DoSomethingVerySlow()));


            Stopwatch timeTakenMultiThreadExecution = new Stopwatch();
            Console.WriteLine("MultiThreaded Calls Started");
            timeTakenMultiThreadExecution.Start();
            await Task.WhenAll(tasks);
            timeTakenMultiThreadExecution.Stop();
            Console.WriteLine("MultiThreaded Calls Ended");
            Console.WriteLine("MultiThreaded Call took: " + timeTakenMultiThreadExecution.ElapsedMilliseconds + "Expected time 20000ms+");


            Stopwatch timeTakenRegularExecution = new Stopwatch();
            Console.WriteLine("Synchronous Calls Started");
            timeTakenRegularExecution.Start();
            await DoSomethingVerySlow();
            await DoSomethingVerySlow();
            await DoSomethingVerySlow();
            await DoSomethingVerySlow();
            await DoSomethingVerySlow();
            await DoSomethingVerySlow();
            await DoSomethingVerySlow();
            await DoSomethingVerySlow();
            timeTakenRegularExecution.Stop();
            Console.WriteLine("Synchronous Calls Ended");
            Console.WriteLine("Synchronous Call took: " + timeTakenRegularExecution.ElapsedMilliseconds + "Expected time 80000ms+");
            Console.ReadLine();
        }

        private static Task DoSomethingFast()
        {
            Console.WriteLine("Fast Method Started");
            Console.WriteLine("Fast Method Completed");
            return Task.CompletedTask;
        }

        private static Task DoSomethingSlow()
        {
            Console.WriteLine("Slow Method Started");
            Thread.Sleep(100);
            Console.WriteLine("Slow Method Completed");
            return Task.CompletedTask;

        }

        private static Task DoSomethingVerySlow()
        {
            Console.WriteLine("Slow Method Started");
            Thread.Sleep(10000);
            Console.WriteLine("Slow Method Completed");
            return Task.CompletedTask;

        }
    }
}
