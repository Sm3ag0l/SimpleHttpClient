using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace SimpleHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => MainAsync());
            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.3.63:5200");
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("", "login")
            });
                var result = await client.PostAsync("/Test/", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }
    }
}
