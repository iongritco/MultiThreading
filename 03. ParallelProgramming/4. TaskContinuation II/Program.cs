namespace TaskContinuation
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() =>
            {
                return 2;
            })
            .ContinueWith((previousTask) =>
            {
                return previousTask.Result * 2;
            });

            task.ContinueWith((previousTask) =>
            {
                return previousTask.Result * 2;
            });

            Console.WriteLine(task.Result);
        }
    }
}
