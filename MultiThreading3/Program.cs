namespace MultiThreading3
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            // trimitem parametri la thread
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
        }

        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine($"ThreadMethod {i}");
                Thread.Sleep(0);
            }
        }
    }
}
