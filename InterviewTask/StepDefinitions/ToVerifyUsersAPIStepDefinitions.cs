using AngleSharp.Common;
using InterviewTask.Support;
using InterviewTask.Support.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace InterviewTask.StepDefinitions
{
    [Binding]
    public class ToVerifyUsersAPIStepDefinitions
    {

        RestHelper helper = new RestHelper();
        string baseURL;
        string endPoint;
        List<User> userList;
        
        [Given(@"I set up a base url as '([^']*)'")]
        public void GivenISetUpABaseUrlAs(string baseUrl)
        {
            this.baseURL = baseUrl;
            this.endPoint = "api/users";
        }

        [When(@"I send a Get user list request from page ""([^""]*)""")]
        public void WhenISendAGetUserListRequestFromPage(string pageNo)
        {
            helper.SetBaseUrl(baseURL, endPoint);
            helper.CreateGetRequest("page", pageNo);
            helper.ExecuteRequest();
            helper.GetResponseContent();
            JArray array = (JArray)helper.parsedOBS["data"];
            userList = array.ToObject<List<User>>();
            Console.WriteLine("converted to list : " + userList.Count);
        }

        [Then(@"Verify Response code is ""([^""]*)""")]
        public void ThenVerifyResponseCodeIs(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)helper.response.StatusCode);
        }

        [Then(@"Verify it returns ""([^""]*)"" users in total as response")]
        public void ThenVerifyItReturnsUsersInTotalAsResponse(string userCount)
        {
            Assert.AreEqual(userCount, userList.Count.ToString());
        }

        [Then(@"Verify Page No ""([^""]*)""")]
        public void ThenVerifyPageNo(string pageNo)
        {
            Assert.AreEqual(pageNo, helper.parsedOBS["page"].ToString());
        }

        [Then(@"Verify result contains user FirstName ""([^""]*)""")]
        public void ThenVerifyResultContainsUserFirstName(string firstName)
        {
            foreach(User user in userList)
            {
                if (user.FirstName == firstName)
                {
                    Assert.AreEqual(firstName, user.FirstName.ToString());
                    break;
                }
            }
          
        }

        [Then(@"Verify result contains user LastName ""([^""]*)""")]
        public void ThenVerifyResultContainsUserLastName(string lastName)
        {
            foreach (User user in userList)
            {
                if (user.LastName == lastName)
                {
                    Assert.AreEqual(lastName, user.LastName.ToString());
                    break;
                }
            }
        }

        [Then(@"Verify result contains user Email ""([^""]*)""")]
        public void ThenVerifyResultContainsUserEmail(string email)
        {
            foreach (User user in userList)
            {
                if (user.Email == email)
                {
                    Assert.AreEqual(email, user.Email.ToString());
                    break;
                }
            }

        }

        [Then(@"Verify result contains user Avatar ""([^""]*)""")]
        public void ThenVerifyResultContainsUserAvatar(string avatar)
        {
            foreach (User user in userList)
            {
                if (user.Avatar == avatar)
                {
                    Assert.AreEqual(avatar, user.Avatar.ToString());
                    break;
                }
            }

        }

    }
}
