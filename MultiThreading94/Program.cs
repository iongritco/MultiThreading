namespace MultiThreading94
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            int[] intList = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = 5 };
            Parallel.ForEach(intList, (i) =>
            {
                Thread.Sleep(2000);
                Console.WriteLine(i);
            });
        }
    }
}
