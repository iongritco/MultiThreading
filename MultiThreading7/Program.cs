namespace MultiThreading7
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            // Task are using ThreadPool and you can see the return value of the thread
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("*");
                }
            });

            // t.Wait is equal with thread.Join - waits until moving forward with the actions
            t.Wait();

            Task<int> t2 = Task.Run(() =>
            {
                Console.WriteLine("Write something inside the thread");
                return 72;
            });

            // when we'll get the result with t.Result, it'll automatically do a t.Wait() in background, so we don't need to specify it
            Console.WriteLine(t2.Result);

            Console.WriteLine("Finish job");
            Console.ReadLine();
        }
    }
}
