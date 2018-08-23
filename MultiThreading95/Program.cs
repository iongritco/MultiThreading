using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading95
{
    using System.Net.Http;

    class Program
    {
        // async or await are not creating any task, they just mark the method/actions as asyncron
        // await here is equal to adding client.GetStringAsync("dsadsa").Result, so it'll wait until the action will be done and will transform the result in desired type
        static void Main(string[] args)
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");

                return result;
            }
        }
    }
}
