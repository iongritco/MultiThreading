namespace SharingData
{
    using System;
    using System.Threading;

    class Program
    {
        //[ThreadStatic]
        public static int field;

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    field++;
                    Console.WriteLine($"Thread 1 {field}");
                }
            });
            thread1.Start();

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    field++;
                    Console.WriteLine($"Thread 2 {field}");
                }
            });
            thread2.Start();
        }
    }
}
