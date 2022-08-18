using FluentAssertions.Execution;
using InterviewTask.Support;
using InterviewTask.Support.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.DevTools;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace InterviewTask.StepDefinitions
{
    [Binding]
    public class CurrentWeatherDataStepDefinitions
    {

        RestHelper helper = new RestHelper();
        string baseURL;
        string endPoint;
        

        [Given(@"Set up a base url as '([^']*)'")]
        public void GivenSetUpABaseUrlAs(string baseUrl)
        {
            this.baseURL = baseUrl;
            this.endPoint = "weather";
            helper.SetBaseUrl(baseUrl,endPoint);
            helper.CreateGetRequest();
        }

       /* [When(@"Set App Id ""([^""]*)"" Coordinates Longitude ""([^""]*)"" latitude ""([^""]*)""")]
        public void WhenSetAppIdCoordinatesLongitudeLatitude(string appId, string lon, string lat)
        {
            helper.CreateGetRequest();
            
            helper.ExecuteRequest();
            helper.GetResponseContent();
        }*/


        [When(@"Set App Id ""([^""]*)""")]
        public void WhenSetAppId(string appId)
        {
            helper.request.AddParameter("appid", appId);
        }

        [When(@"Set Coordinates Longitude ""([^""]*)"" latitude ""([^""]*)""")]
        public void WhenSetCoordinatesLongitudeLatitude(string lon, string lat)
        {
            helper.request.AddParameter("lon", lon);
            helper.request.AddParameter("lat", lat);
        }

        [Then(@"Verify Status code ""([^""]*)""")]
        public void ThenVerifyStatusCode(int statusCode)
        {
            helper.ExecuteRequest();
            helper.GetResponseContent();
            /*helper.parsedOBS;*/
            Assert.AreEqual(statusCode, (int)helper.response.StatusCode);
        }

        [Then(@"Verify Status Message ""([^""]*)""")]
        public void ThenVerifyStatusMessage(string oK)
        {
            if ((int)helper.response.StatusCode == 200)
            {
                Assert.AreEqual(helper.response.StatusCode.ToString().ToUpper(), oK.ToUpper());
            }
            else
            {
                Assert.AreEqual(helper.parsedOBS["message"].ToString().ToUpper(), oK.ToUpper());
            }
        }

        [Then(@"Verify Response coord includes:")]
        public void ThenVerifyResponseCoordIncludes(Table table)
        {
            JObject obj = (JObject)helper.parsedOBS["coord"];
            
            Coord coord = new Coord();
            coord.Lat = (string)obj["lat"].ToString() +"";
            coord.Lon = (string)obj["lon"].ToString() + "";

            table.CompareToInstance<Coord>(coord);
        }

        [Then(@"Verify Response Coordinates Longitude ""([^""]*)"" latitude ""([^""]*)""")]
        public void ThenVerifyResponseCoordinatesLongitudeLatitude(string lon, string lat)
        {
            JObject obj = (JObject)helper.parsedOBS["coord"];

            Coord coord = new Coord();
            coord.Lat = (string)obj["lat"].ToString() + "";
            coord.Lon = (string)obj["lon"].ToString() + "";

            Assert.AreEqual(coord.Lat, lat);
            Assert.AreEqual(coord.Lon, lon);
        }

        [Then(@"Verify Country ""([^""]*)""")]
        public void ThenVerifyCountry(string country)
        {
            JObject obj = (JObject)helper.parsedOBS["sys"];

            Assert.AreEqual(obj["country"].ToString(), country);
        }

        [Then(@"Verify Weather Should not empty")]
        public void ThenVerifyWeatherShouldNotEmpty()
        {

            JArray array = (JArray)helper.parsedOBS["weather"];
            List<Weather> list = array.ToObject<List<Weather>>();
            Console.WriteLine("converted to list : " + list.Count);

            Weather weather = list[0];
            Assert.IsNotNull(weather.Id);
            Assert.IsNotNull(weather.Main);
            Assert.IsNotNull(weather.Description);
            Assert.IsNotNull(weather.Icon);

        }

        [Then(@"Verify main temprature pressure humidity should not empty or null")]
        public void ThenVerifyMainTempraturePressureHumidityShouldNotEmptyOrNull()
        {
            JObject obj = (JObject)helper.parsedOBS["main"];
            Main main = obj.ToObject<Main>();

            Assert.IsNotNull(main.Temp);
            Assert.IsNotNull(main.Pressure);
            Assert.IsNotNull(main.Humidity);
        }



    }
}
