namespace Lock
{
    using System;
    using System.Threading;

    class Program
    {
        private static object locker = new object();

        static void Main(string[] args)
        {
            int n = 0;
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (locker)
                    {
                        n++;
                    }
                }
            });

            thread.Start();

            for (int i = 0; i < 1000000; i++)
            {
                lock (locker)
                {
                    n--;
                }
            }

            thread.Join();
            Console.WriteLine($"Result: {n}");
        }
    }
}
