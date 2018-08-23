namespace MultiThreading6
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            // new Thread() - after thread finishes the job, the thread is destroyed
            // if you use new Thread() you can crash the server is there are too many instances - remember cleanup job
            // TreadPool - managed thread instances and recycle previously created threads from thread pool.
            // The problem with thread pool is that you cannot see when the action is finished or the result of the thread
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from thread pool");
            });

            Console.ReadLine();
        }
    }
}
