using System.Threading;

namespace SharingData
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main thread";
            Thread thread = new Thread(DoSomething);
            thread.Name = "Second thread";
            thread.Start();

            DoSomething();

            thread.Join();

            Console.WriteLine("Finished job");
        }

        public static void DoSomething()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Do something: {i}, Thread: {Thread.CurrentThread.Name}");
                Thread.Sleep(10);
            }
        }
    }
}
