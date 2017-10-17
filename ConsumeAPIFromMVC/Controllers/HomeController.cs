using ConsumeAPIFromMVC.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsumeAPIFromMVC.Controllers
{
    public class HomeController : Controller
    {
        const string userName = "frankenstine@gmail.com";
        const string password = "Abcd1234.";
        const string apiBaseUri = "http://localhost:27203";
        const string apiGetPeoplePath = "/api/EmailConfiguration/1";

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            //Start consuming api 
            var token = CustomAPIHelpers.GetAPIToken(userName, password, apiBaseUri).Result;

            var response = CustomAPIHelpers.GetRequest(token, apiBaseUri, apiGetPeoplePath).Result;

            EmailConfiguration emailConfiguration = JsonConvert.DeserializeObject<EmailConfiguration>(response);

            return View(emailConfiguration);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //private static async Task<string> GetAPIToken(string userName, string password, string apiBaseUri)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        //setup client
        //        client.BaseAddress = new Uri(apiBaseUri);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        //setup login data
        //        var formContent = new FormUrlEncodedContent(new[]
        //        {
        //         new KeyValuePair<string, string>("grant_type", "password"),
        //         new KeyValuePair<string, string>("username", userName),
        //         new KeyValuePair<string, string>("password", password),
        //        });

        //        //send request
        //        HttpResponseMessage responseMessage = await client.PostAsync("/Token", formContent);

        //        //get access token from response body
        //        var responseJson = await responseMessage.Content.ReadAsStringAsync();
        //        var jObject = JObject.Parse(responseJson);
        //        return jObject.GetValue("access_token").ToString();
        //    }
        //}

        //static async Task<string> GetRequest(string token, string apiBaseUri, string requestPath)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        // Setup client
        //        client.BaseAddress = new Uri(apiBaseUri);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //        // Make request
        //        HttpResponseMessage response = await client.GetAsync(requestPath);
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        return responseString;
        //    }
        //}

    }
}