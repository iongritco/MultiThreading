namespace ThreadPool
{
    using System;
    using System.Threading;

    class Program
    {
        private static ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working on a thread from thread pool");
                resetEvent.Set();
            });

            resetEvent.WaitOne();
            Console.WriteLine("Main thread");
        }
    }
}
