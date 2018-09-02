namespace TaskContinuation
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task<int> newTask = Task.Run(() =>
            {
                return 2;
            })
            .ContinueWith((task) =>
            {
                return task.Result * 2;
            });

            newTask.ContinueWith((task) =>
            {
                return task.Result * 2;
            });

            Console.WriteLine(newTask.Result);
        }
    }
}
