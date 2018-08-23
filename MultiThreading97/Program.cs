namespace MultiThreading97
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        // example of DEADLOCK
        static void Main(string[] args)
        {
            object locked1 = new object();
            object locked2 = new object();
            Task myTask = Task.Run(() =>
            {
                lock (locked1)
                {
                    Thread.Sleep(5000);
                    lock (locked2)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            lock (locked2)
            {
                Thread.Sleep(1000);
                lock (locked1)
                {
                    Console.WriteLine("Locked B and A");
                }
            }

            myTask.Wait();
        }
    }
}
