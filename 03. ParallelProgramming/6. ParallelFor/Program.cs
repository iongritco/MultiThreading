namespace Parallel
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                DoSomeAction(i);
            }

            Console.WriteLine("Finished regular For");

            Parallel.For(0, 10, (i) =>
            {
                DoSomeAction(i);
            });

            Console.WriteLine("Finished parallel for");
        }

        static void DoSomeAction(int i)
        {
            Console.WriteLine($"Do some action for {i}");
            Thread.Sleep(500);
        }
    }
}
