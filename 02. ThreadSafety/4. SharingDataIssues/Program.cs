namespace SharingDataIssues
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    n = n + 1;
                }
            });

            thread.Start();

            for (int i = 0; i < 1000000; i++)
            {
                n = n - 1;
            }

            thread.Join();
            Console.WriteLine($"Result: {n}");
        }
    }
}
