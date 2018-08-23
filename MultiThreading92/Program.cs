namespace MultiThreading92
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task<int>[] tasks = new Task<int>[2];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task 1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 2");
                return 2;
            });

            // wait for multiple thread to complete
            // Task.WaitAll(tasks);

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }
    }
}
