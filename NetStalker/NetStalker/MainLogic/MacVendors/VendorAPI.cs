using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace NetStalker
{
    public class VendorAPI
    {
        private static string Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImp0aSI6IjE3MWUzMDdjLTJhM2EtNDFiYi04OWJjLWZkMjk4NTViMzBkNiJ9.eyJpc3MiOiJtYWN2ZW5kb3JzIiwiYXVkIjoibWFjdmVuZG9ycyIsImp0aSI6IjE3MWUzMDdjLTJhM2EtNDFiYi04OWJjLWZkMjk4NTViMzBkNiIsImlhdCI6MTU2Mzk3NTQxMiwiZXhwIjoxODc4NDcxNDEyLCJzdWIiOiIxNzIwIiwidHlwIjoiYWNjZXNzIn0.NSuEiqHllfH_TQh8IXjzijsXFdcyRIcbDap5WExsXzlSv8ys4BR10SQn1jvAGTku35Aq8RTBZqs6STmCFM7CSA";
        public static VendorClass GetVendorInfo(string MAC)
        {
            int tries = 0;
            rerun:
            try
            {
                WebRequest wb = WebRequest.Create($"https://api.macvendors.com/v1/lookup/{MAC.Remove(MAC.Length - 4, 4)}");
                HttpWebRequest hwr = (HttpWebRequest)wb;
                hwr.PreAuthenticate = true;
                hwr.Headers.Add("Authorization", "Bearer " + Token);

                HttpWebResponse hwrr = (HttpWebResponse)wb.GetResponse();
                if (hwrr.StatusCode == HttpStatusCode.NotFound) { return default; }

                var ResponseStream = hwrr.GetResponseStream();
                if (ResponseStream == null) { return default; }

                VendorClass Vendor;
                using (StreamReader SR = new StreamReader(ResponseStream))
                {
                    var res = SR.ReadToEnd();

                    Vendor = JsonConvert.DeserializeObject<VendorClass>(res);
                }

                if (Vendor != null)
                {
                    return Vendor;
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("429") && tries <= 5)
                {
                    Thread.Sleep(2000);
                    tries++;
                    goto rerun;
                }
            }

            return default;
        }
    }

}

