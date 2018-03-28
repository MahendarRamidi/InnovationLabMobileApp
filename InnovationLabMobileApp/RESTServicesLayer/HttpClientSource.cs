using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FindLocation
{
    public class HttpClientSource<T> where T : class
    {
        static HttpClient client;

        static HttpClientSource()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://apis.oneposcloud./");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "");
            client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<string> CreateOrUpdateItemWithPostAsync(string methodName, T t)
        {
            var postData = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
            string returnVal = "";
            try
            {
                HttpResponseMessage response = await client.PostAsync(methodName, postData);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    returnVal = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                returnVal = null;
            }
            return returnVal;
        }

        public static async Task<T> RetriveDataWithGetAsync(string methodName)
        {
            T t = null;
            HttpResponseMessage response = await client.GetAsync(methodName);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                t = JsonConvert.DeserializeObject<T>(str);
            }
            return t;
        }
    }
}