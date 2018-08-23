namespace MultiThreading9
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 2;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            t = t.ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            // t = t.

            Console.WriteLine(t.Result);
        }
    }
}
