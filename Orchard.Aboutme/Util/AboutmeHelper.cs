using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Orchard.Aboutme.Util
{
    public class AboutmeHelper
    {
        private static readonly string ABOUTME_URL = "https://api.about.me/api/v2/json/user/view/";
        private static readonly string CLIENT_ID = "11e3c3a6e489a7059fd1988be754c376e2c4694f";

        public static JObject GetAboutmeInfo(string username)
        {
            string aboutmeApiUrl = string.Format("{0}/{1}?client_id={2}&strip_html=false&extended=true", ABOUTME_URL, username, CLIENT_ID);
            JObject userInfo = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpResponse = httpClient.GetStringAsync(aboutmeApiUrl);
                userInfo = JsonConvert.DeserializeObject<JObject>(httpResponse.Result);         //Parse the result as object
            }
            return userInfo;
        }
    }
}