namespace MultiThreading96
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        // lock it's used to block concurent thread to use the same resources
        static void Main(string[] args)
        {
            int n = 0;
            object locked = new object();
            Task myTask = Task.Run(() => {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (locked)
                    {
                        n = n +1;
                        Interlocked.Increment(ref n);
                    }
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock (locked)
                {
                    n--;
                    // Interlocked.Decrement(ref n);
                }
            }

            myTask.Wait();
            Console.WriteLine(n);
        }
    }
}
