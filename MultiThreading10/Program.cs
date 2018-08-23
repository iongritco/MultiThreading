namespace MultiThreading10
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
                {
                    Console.WriteLine("Main thread");
                    throw new Exception();
                })
                .ContinueWith((i) => { Console.WriteLine("Only on faulted"); }, TaskContinuationOptions.OnlyOnFaulted);

            t.Wait();
        }
    }
}
