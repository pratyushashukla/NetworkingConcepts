using System;
using System.Net.Http;
using HttpWebApi;

namespace HTTPClientAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http:/localhost:44334/weatherforecast/Get/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage resmsg = client.GetAsync("api/Values").Result;
            if(resmsg.IsSuccessStatusCode)
            {
                var products = resmsg.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} {1}",(int) resmsg.StatusCode,resmsg);
            }
        }
    }
}
