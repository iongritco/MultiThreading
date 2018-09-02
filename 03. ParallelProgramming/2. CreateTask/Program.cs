namespace CreateTask
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Do some work on the first task");
                Thread.Sleep(500);
            });

            task.Wait();

            Task<int> task2 = Task.Run(() =>
            {
                Console.WriteLine("Do some work on the second task");
                Thread.Sleep(1000);
                return 72;
            });

            Console.WriteLine($"Returned value from second task {task2.Result}");

            Task task3 = Task.Run(action: DoSomething);
            Task task4 = Task.Run(action: DoSomething);

            Task.WaitAll(task3, task4);
        }

        private static void DoSomething()
        {
            Console.WriteLine($"Do some work on task {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
        }
    }
}
