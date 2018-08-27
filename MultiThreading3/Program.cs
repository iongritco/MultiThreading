namespace MultiThreading
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(threadParameter =>
            {
                for (int i = 0; i < (int)threadParameter; i++)
                {
                    Console.WriteLine($"Worker thread: {i}");
                }
            });
            thread.Start(5);
            thread.Join();

            Console.WriteLine("Finished job");
        }
    }
}
