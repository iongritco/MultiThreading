namespace MultiThreading
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(DoSomethingOnWorkerThread);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Lowest;
            thread.Name = "Custom Worker Thread";
            thread.Start(10);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main thread: {i}");
                Thread.Sleep(50);
            }

            //thread.Join();
            Console.WriteLine("Finished job");
        }

        public static void DoSomethingOnWorkerThread(object threadParameter)
        {
            for (int i = 0; i < (int)threadParameter; i++)
            {
                Console.WriteLine($"Worker thread: {i}");
                Thread.Sleep(100);
            }
        }
    }
}
