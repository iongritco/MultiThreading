namespace Parallel
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;

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
            foreach (var siteUrl in sites)
            {
                var result = DownloadContentAsync(siteUrl).Result;
                Console.WriteLine($"{siteUrl} - {result.Length}");
            }
            stopWatch.Stop();
            Console.WriteLine($"-------------Time for regular ForEach: {stopWatch.ElapsedMilliseconds}");

            stopWatch.Restart();
            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = sites.Length };
            Parallel.ForEach(sites, options, (siteUrl) =>
            {
                var result = DownloadContentAsync(siteUrl).Result;
                Console.WriteLine($"{siteUrl} - {result.Length}");
            });
            stopWatch.Stop();
            Console.WriteLine($"------------Time for parallel ForEach: {stopWatch.ElapsedMilliseconds}");
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
