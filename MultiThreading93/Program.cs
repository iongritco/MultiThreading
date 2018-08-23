namespace MultiThreading93
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Parrallel.For and Parralel.ForEach are using task, so this means they are using ThreadPool
    /// they should be used in cases when you need to parallelize actions for a list where an action is independent of all other element list
    /// we don't know the order for Parralel.For and Parralel.ForEach since they are running in parralel
    /// This means that we should not expect to run from 1 to 10 like an usual for, because it'll not run in order
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

            Parallel.For(0, 10, (i) =>
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            });
        }
    }
}
