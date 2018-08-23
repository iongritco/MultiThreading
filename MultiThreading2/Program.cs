
namespace MultiThreading2
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            // t.IsBackground - threadul o sa ruleze in background si in cazul unei console nu va afisa nimic in interfata
            t.IsBackground = true;
            t.Start();

            t.Join();
            Console.WriteLine("Finish job");
            // Console.ReadLine();
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadMethod {i}");
                Thread.Sleep(10);
            }
        }
    }
}
