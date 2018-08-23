namespace MuliThreading5
{
    using System;
    using System.Threading;

    class Program
    {
        [ThreadStatic]
        public static int field;

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    field++;
                    Console.WriteLine($"Thread 1 {field}");
                }
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    field++;
                    Console.WriteLine($"Thread 2 {field}");
                }
            });
            t2.Start();
        }
    }
}
