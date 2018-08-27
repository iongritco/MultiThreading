namespace MultiThreading
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(DoSomethingOnWorkerThread);
            thread.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main thread: {i}");
                Thread.Sleep(10);
            }

            thread.Join();

            Console.WriteLine("Finished job");
        }

        public static void DoSomethingOnWorkerThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Worker thread: {i}");
                Thread.Sleep(10);
            }
        }
    }
}
