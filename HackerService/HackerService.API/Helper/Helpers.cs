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
