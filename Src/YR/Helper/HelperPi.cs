//Experimental

using System;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace YandexTrains.Helper
{
    public class HelperPi
    {
        private static string[] codes_dict;

        public static void Init()
        {
            string api_key = "3d4db511-c803-4569-a638-e0babb6cbccc";//"your_api_key";
            string api_url = "https://api.rasp.yandex.net/v3.0/schedule/";
            string to_code = "to_code";
            string from_code = "from_code";

            FindCode(to_code);
            SchBetweenRoutes(api_key, api_url, to_code, from_code);
            ReqStationCodes(api_key);
        }

        public static void FindCode(string to_inp)
        {
            string code = default;//codes_dict[to_inp];
            Debug.WriteLine("code = " + code);
        }

        public static void SchBetweenRoutes(string api_key, string api_url, 
            string to_code, string from_code)
        {
            string format = "json";
            string from1 = from_code;
            string to = to_code;
            string lang = "ru";
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            Dictionary<string, string> payload = new Dictionary<string, string>()
        {
            {"apikey", api_key},
            {"from", from1},
            {"to", to},
            {"format", format}
        };

            HttpClient client = new HttpClient();

            // api_url, ,new FormUrlEncodedContent(payload)
            HttpResponseMessage response = client.GetAsync(api_url).Result;


            string resp = response.Content.ReadAsStringAsync().Result;

            Debug.WriteLine(resp);
        }

        public static void ReqStationCodes(string api_key)
        {
            Dictionary<string, string> payload1 = new Dictionary<string, string>()
        {
            {"apikey", api_key},
            {"format", "json"}
        };

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(
                "https://api.rasp.yandex.net/v3.0/stations_list/" +
                "?apikey=3d4db511-c803-4569-a638-e0babb6cbccc&lang=ru_ru&format=json")
                .Result;

            string resp = response.Content.ReadAsStringAsync().Result;

            Dictionary<string, char> distros_dict = 
                JsonConvert.DeserializeObject<Dictionary<string, char>>(resp);
            
            List<object> doc = new List<object>();

            Dictionary<string, char> res_cd = new Dictionary<string, char>();

        }
    }
}





