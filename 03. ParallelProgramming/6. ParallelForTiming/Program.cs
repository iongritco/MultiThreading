namespace Parallel
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
            }
            stopWatch.Stop();
            Console.WriteLine("Finished regular For");
            Console.WriteLine($"Total time in milliseconds: {stopWatch.ElapsedMilliseconds}");

            stopWatch.Restart();
            Parallel.For(0, 100, (i) =>
            {
                Console.Write("*");
            });
            stopWatch.Stop();
            Console.WriteLine("Finished parallel For");
            Console.WriteLine($"Total time in milliseconds: {stopWatch.ElapsedMilliseconds}");
        }
    }
}
