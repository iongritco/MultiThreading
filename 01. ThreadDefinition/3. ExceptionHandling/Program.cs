namespace ExceptionHandling
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread thread = new Thread(DoSomething);
                thread.Start();

                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Main thread: {i}");
                    Thread.Sleep(10);
                }

                thread.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Catched exception from the worker thread: {ex.Message}");
            }
        }

        public static void DoSomething()
        {
            throw new Exception();
        }
    }
}
