using System;
using Zendid.Models;

namespace HttpPostReq
{
    class Program
    {

        static void Main(string[] args)
        {

        }

        private async void Login()
        {
            InputClass log = new InputClass { 
                Username = "Nick",
                Password = "n123123"
            };

            var res = await ApiClient.RequestServerPost<InputClass, string>
                ("https://zendid.in.kutiika.net/account/login", log);

            Console.WriteLine(res);
        }
    }
}
