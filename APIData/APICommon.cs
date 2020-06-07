using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace APIData
{
    // This class is to make one instance of HTTP for whole application
    // Not want to open multiple port for single application
    // And also optise performance
    public static class APICommon
    {
        public static HttpClient ClientAPI { get; set; }

        public static void initilizeAPI()
        {
            ClientAPI = new HttpClient();
            ClientAPI.DefaultRequestHeaders.Clear();

            //Accept json type format data
            ClientAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
