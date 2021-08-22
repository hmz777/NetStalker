using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace NetStalker
{
    public class VendorAPI
    {
        private static string Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImp0aSI6IjE3MWUzMDdjLTJhM2EtNDFiYi04OWJjLWZkMjk4NTViMzBkNiJ9.eyJpc3MiOiJtYWN2ZW5kb3JzIiwiYXVkIjoibWFjdmVuZG9ycyIsImp0aSI6IjE3MWUzMDdjLTJhM2EtNDFiYi04OWJjLWZkMjk4NTViMzBkNiIsImlhdCI6MTU2Mzk3NTQxMiwiZXhwIjoxODc4NDcxNDEyLCJzdWIiOiIxNzIwIiwidHlwIjoiYWNjZXNzIn0.NSuEiqHllfH_TQh8IXjzijsXFdcyRIcbDap5WExsXzlSv8ys4BR10SQn1jvAGTku35Aq8RTBZqs6STmCFM7CSA";
        private static HttpClient HttpClient;
        private static bool HttpClientReady;

        private static void InitHttpClient()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
        }

        public async static Task<VendorClass> GetVendorInfo(string MAC)
        {
            if (!HttpClientReady)
            {
                InitHttpClient();
                HttpClientReady = true;
            }

            int tries = 0;

            try
            {
                while (tries <= 5)
                {
                    var ResponseMessage = await HttpClient.GetAsync(new Uri($"https://api.macvendors.com/v1/lookup/{MAC.Remove(MAC.Length - 4, 4)}"));

                    if (ResponseMessage.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        Thread.Sleep(2000);
                        tries++;
                        continue;
                    }
                    else if (!ResponseMessage.IsSuccessStatusCode)
                    {
                        return default;
                    }

                    VendorClass Vendor;

                    string Response = await ResponseMessage.Content.ReadAsStringAsync();
                    Vendor = JsonSerializer.Deserialize<VendorClass>(Response);

                    if (Vendor != null)
                    {
                        return Vendor;
                    }
                }
            }
            catch
            {
                throw;
            }

            return default;
        }
    }
}