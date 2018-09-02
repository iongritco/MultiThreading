namespace Deadlock
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            object lockA = new object();
            object lockB = new object();
            Thread thread = new Thread(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(5000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            thread.Start();

            lock (lockB)
            {
                Thread.Sleep(1000);
                lock (lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }

            thread.Join();
            Console.WriteLine("Finished job");
        }
    }
}
