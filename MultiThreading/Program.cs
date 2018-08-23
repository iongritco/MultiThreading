namespace MultiThreading
{
    using System;
    using System.Threading;

    class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadMethod {i}");
                // elibereaza threadul si in caz ca exista un thread cu o prioritate mai mare, ala va porni 
                Thread.Sleep(0);
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"MainThread {i}");
                Thread.Sleep(0);
            }

            // main thread will wait for the t thread in order to continue the main process - if we have join it'll print immediatelly, otherwise it'll print just after the second thread finished
            t.Join();

            Console.WriteLine("Finish job");
        }
    }
}
