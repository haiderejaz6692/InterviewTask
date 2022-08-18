using AngleSharp.Common;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InterviewTask.Support
{
    public class RestHelper
    {
        public RestClient client { get; set; }
        public RestRequest request { get; set; }
        public RestResponse response { get; set; }
        public JObject parsedOBS { get; set; }
        public RestClient SetBaseUrl(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            
            return client;
        }

        public RestRequest CreateGetRequest(string parmkey,string paramValue)
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };

            request.AddParameter(parmkey, paramValue);

           /* request.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }

            });*/
            return request;
        }

        public RestRequest CreateGetRequest(string[] param)
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };

            request.AddObject(param);


            /* request.AddHeaders(new Dictionary<string, string>
             {
                 { "Accept", "application/json" },
                 { "Content-Type", "application/json" }

             });*/
            return request;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            /* request.AddHeaders(new Dictionary<string, string>
             {
                 { "Accept", "application/json" },
                 { "Content-Type", "application/json" }

             });*/
            return request;
        }

        public RestResponse ExecuteRequest()
        {
            response = client.Execute(request);
            return response;
        }

        public JObject GetResponseContent()
        {
            parsedOBS = JObject.Parse(response.Content);
            return parsedOBS;
        }

        public JObject GetSpecificObject(string firstName)
        {
            JObject finalItem = new JObject();
            JArray array = (JArray)parsedOBS["data"];
            foreach (JObject item in array)
            {
                if (item.ToString() == firstName)
                {
                    finalItem = (JObject)array.IndexOf(item);
                    break;
                }
            }

            return finalItem;
        }
    }
}
