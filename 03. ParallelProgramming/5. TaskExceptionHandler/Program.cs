using System;
using System.Threading.Tasks;

namespace TaskExceptionHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task task = Task.Run(action: DoSomething);
                task.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Catched the error: {ex.InnerException}");
            }

            Console.WriteLine("Finished job");
        }

        private static void DoSomething()
        {
            throw new Exception();
        }
    }
}
