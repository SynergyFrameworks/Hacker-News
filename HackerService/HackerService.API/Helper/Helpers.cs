using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace HackerService.API.Helper
{
    public class Helpers
    {
        private Dictionary<string, string> defaultHeaderMap = new Dictionary<string, string>();
        Helpers()
        {
   
            //string[] arr = { "car", "bike", "truck", "bus" };
            //foreach (var t in arr)
            //{
            //    Console.Write("{0} ", t);
            //}
            //Console.WriteLine();
            //var res = Array.Find(arr, ele => ele.StartsWith("t",
            //    StringComparison.Ordinal));

        }


        public void addDefaultHeader(string key, string value)
        {
            defaultHeaderMap.Add(key, value);
        }

        public string escapeString(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static object deserialize(string json, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, type);
            }
            catch (IOException e)
            {
                throw new System.Text.Json.JsonException();
            }

        }

        public static string serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }) : null;

            }
            catch (Exception)
            {
                throw new System.Text.Json.JsonException();
            }
        }





    }
}
