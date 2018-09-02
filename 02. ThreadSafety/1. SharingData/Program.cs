namespace SharingData
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            var stopped = false;

            Thread thread = new Thread(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running ...");
                    Thread.Sleep(1000);
                }
            });
            thread.Start();

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
            stopped = true;

            thread.Join();
        }
    }
}
