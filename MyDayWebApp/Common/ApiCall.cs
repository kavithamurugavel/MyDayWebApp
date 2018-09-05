using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyDayWebApp.Common
{
    // makes the api call using HttpWebRequest
    public class ApiCall
    {
        public string GetJSONStringFromAPI(string apiString)
        {
            string jsonString = null;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(apiString);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponseAsync().Result;

            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            return jsonString;
        }
    }
}
