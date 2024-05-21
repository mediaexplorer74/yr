using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YandexTrains.Model;

namespace YandexTrains.Helper
{
    public class Helper
    {
        public List<string> stations;

        public static async Task<List<Route>> GetRoutesList(string lat,string lon)
        {            
            //A list to return the schedule in list
            List<Route> schedule = new List<Route>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(Common.Common.APIRequest(lat, lon));
                var json = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == System.Net.HttpStatusCode.OK) 
                {                                     

                    dynamic responce = JObject.Parse(json);
                    int length = 100;
                    try
                    {
                        for (int i = 0; i < length; i++)
                        {
                            Route route = new Route();                           
                            route.depart = responce.schedule[i].departure;                             
                            schedule.Add(route);
                        }                        
                        return schedule;
                    }
                    catch (Exception ex)
                    {
                        return schedule;
                    }
                }
                return null;
            }
        }
    }
}
