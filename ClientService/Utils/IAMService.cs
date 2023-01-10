using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Utils
{
    public class IAMService
    {

        public static string Token(string realm, List<KeyValuePair<String, String>> postData)
        {
            string res = string.Empty;
            string url = "http://10.1.240.16:8080/auth/realms/"+realm+"/protocol/openid-connect/token";

            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = httpClient.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        res = response.Content.ReadAsStringAsync().Result;
                        var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(res);
                        string Data = obj.access_token;
                        return Data;
                    }
                }
            }
            return res;
        }

        public static string ConsumeKeycloakService(object input, string url, string token)
        {
            string res = string.Empty;
            HttpClient client = new HttpClient();
            try
            {
                string x = Newtonsoft.Json.JsonConvert.SerializeObject(input);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer "+token);
                HttpContent inputContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, inputContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    res = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    res = string.Empty;
                }
            }
            catch(Exception ex)
            {
                res = string.Empty;
            }
            return res;
        }


        public static string VerifyTokenKeycloak( string url, string token)
        {
            string res = string.Empty;
            HttpClient client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    res = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    res = string.Empty;
                }
            }
            catch (Exception ex)
            {
                res = string.Empty;
            }
            return res;



            
        }
    }
}
