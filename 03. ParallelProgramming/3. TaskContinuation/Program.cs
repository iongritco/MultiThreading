namespace TaskContinuation
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Do some action in the first task");
            })
            .ContinueWith((previousTask) =>
            {
                Console.WriteLine("Continue the action in the second task");
                throw new Exception();
            })
            .ContinueWith((previousTask) =>
            {
                Console.WriteLine("Only on faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            task.Wait();
        }
    }
}
