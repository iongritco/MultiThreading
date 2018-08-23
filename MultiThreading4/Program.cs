
namespace MultiThreading4
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            bool stopped = false;

            // In case we need variables that are visible in multiple thread we can use lamba functions when creating a new thread
            Thread t = new Thread(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running ...");
                    Thread.Sleep(1000);
                }
            });
            t.Start();


            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
            stopped = true;
            t.Join();
        }
    }
}
