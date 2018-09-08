using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var sites = new[] { "http://www.softvision.com",
                                "http://www.google.com",
                                "http://www.microsoft.com",
                                "http://www.apple.com",
                                "http://www.youtube.com" };

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = sites.Where(x => DownloadContentAsync(x).Result.Length > 10000).Count();
            stopWatch.Stop();
            Console.WriteLine($"Number of sites with lenght>10000 - {result}");
            Console.WriteLine($"-------------Time for regular LINQ: {stopWatch.ElapsedMilliseconds}");

            stopWatch.Restart();
            result = sites.AsParallel().Where(x => DownloadContentAsync(x).Result.Length > 10000).Count();
            stopWatch.Stop();
            Console.WriteLine($"Number of sites with lenght>10000 - {result}");
            Console.WriteLine($"------------Time for PLINQ: {stopWatch.ElapsedMilliseconds}");
        }

        public static async Task<string> DownloadContentAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}
