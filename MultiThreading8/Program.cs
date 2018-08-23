namespace MultiThreading8
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            // trimitem parametri la thread
            Task t = Task.Run(action: ThreadMethod);
            t.Wait();
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadMethod {i}");
            }
        }
    }
}
