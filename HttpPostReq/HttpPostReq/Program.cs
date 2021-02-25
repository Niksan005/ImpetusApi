using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace HttpPostReq
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            InputClass log = new InputClass
            {
                Username = "Nick",
                Password = "n123123"
            };
            var json = JsonConvert.SerializeObject(log);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44378/weatherforecast";
            using var client = new HttpClient();


            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

    }
}
