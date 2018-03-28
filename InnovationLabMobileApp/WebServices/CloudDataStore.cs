using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InnovationLabMobileApp.Models;
using Newtonsoft.Json;

namespace InnovationLabMobileApp
{
    public class CloudDataStore
    {
        HttpClient client;
        string[] name;
        string[] names;
        string matched;

        public CloudDataStore()
        {
            client = new HttpClient();
            //client.BaseAddress = new Uri($"{App.BackendUrl} /");

        }
        // Previous 30 days visitors "GET" Json Data
        public async Task<string[]> GetRegisteredUser()
        {
            var json = await client.GetStringAsync("http://107.21.149.43:8080/visitorRegister/viewLast30days");
            names = await Task.Run(() =>
                                   JsonConvert.DeserializeObject<string[]>(json));
            return names;
        }
        // GetBarcode "GET" Json Data
        public async Task<string> GetBarcode(string Barcode)
        {
            try
            {
                var response = await client.GetStringAsync("http://107.21.149.43:8080/barcode/getBarcodeInfo/" + Barcode);
                return response;
            }
            catch(Exception ex)
            {
                return null;
            }           
        }
        //Lab Registration "POST" Json Data
        public async Task<bool> AddRegisteredUser(string name, string date = "", string time = "", string topic = "")
        {
            if (name == null)//!CrossConnectivity.Current.IsConnected                 return false;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["VisitorName"] = name;
            dict["Date"] = date;
            dict["Time"] = time;
            dict["Topic"] = topic;
            var serializedItem = JsonConvert.SerializeObject(dict);

            var response = await client.PostAsync("http://107.21.149.43:8080/visitorRegister/addRecord", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }
        //Event Registration "POST" Json Data
        public async Task<bool> AddRegisteredEvent(Dictionary<string, string> dict)
        {
            if (dict == null)//!CrossConnectivity.Current.IsConnected                 return false;

            var serializedItem = JsonConvert.SerializeObject(dict);

            var response = await client.PostAsync("http://107.21.149.43:8080/eventRegister/addRecord", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }

        //Idea Exchange "POST" Json Data
        public async Task<bool> IdeaExchange(Dictionary<string, string> dict)
        {
            if (dict == null)//!CrossConnectivity.Current.IsConnected
                return false;

            var serializedItem = JsonConvert.SerializeObject(dict);

            var response = await client.PostAsync("http://107.21.149.43:8080/works/addIdea", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }
        //Schedule a tour "POST" JSON Data
        public async Task<bool> AddScheduleTour(Dictionary<string, string> dict)
        {
            if (dict == null)//!CrossConnectivity.Current.IsConnected
                return false;

            var serializedItem = JsonConvert.SerializeObject(dict);

            var response = await client.PostAsync("http://107.21.149.43:8080/scheduleTour/addTour", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }
        //Survey submit "POST" JSON Data
        public async Task<bool> AddSurveyResult(List<SurveyResult> request)
        {
            if (request == null)//!CrossConnectivity.Current.IsConnected
                return false;

            var serializedItem = JsonConvert.SerializeObject(request);

            var response = await client.PostAsync("http://107.21.149.43:8080/survey/addSurveyResult", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }
        ////Sign Up Page "POST" Json Data
        public async Task<bool> AddSignupRecord(Dictionary<string, string> dict)
        {
            if (dict == null)//!CrossConnectivity.Current.IsConnected
                return false;

            var serializedItem = JsonConvert.SerializeObject(dict);

            var response = await client.PostAsync("http://107.21.149.43:8080/register/addRecord", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }
        // Login Check
        public async Task<bool> CheckLogin(Dictionary<string, string> dict)
        {
            if (dict == null)//!CrossConnectivity.Current.IsConnected
                return false;

            var serializedItem = JsonConvert.SerializeObject(dict);

            var response = await client.PostAsync("http://107.21.149.43:8080/register/checkLogin", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            matched = await Task.Run(() =>
                                     response.Content.ReadAsStringAsync());

            if (matched == "matched")
            {
                return true;
            }
            return false;

        }
        // Prototypes "GET" JSON Data
        public async Task<List<Prototype>> GetPrototypes()
        {
            var json = await client.GetStringAsync("http://107.21.149.43:8080/works/viewPrototypes");
            List<Prototype> response = await Task.Run(() =>
                                                      JsonConvert.DeserializeObject<List<Prototype>>(json));
            return response;
        }
        // White Papers "GET" JSON Data
        public async Task<List<WhitePaper>> GetWhitePapers()
        {
            var jsons = await client.GetStringAsync("http://107.21.149.43:8080/works/viewWhitepapers");
            List<WhitePaper> responses = await Task.Run(() =>
                                                       JsonConvert.DeserializeObject<List<WhitePaper>>(jsons));
            return responses;
        }
        // Tech Surv "GET" JSON Data
        public async Task<List<TechSurv>> GetTechSurv()
        {
            var json = await client.GetStringAsync("http://107.21.149.43:8080/works/viewTechSurv");
            List<TechSurv> response = await Task.Run(() =>
                                                     JsonConvert.DeserializeObject<List<TechSurv>>(json));
            return response;
        }
        // Upcoming Events "GET" JSON Data
        public async Task<List<UpcomingEvent>> GetUpcomingEvents()
        {
            var json = await client.GetStringAsync("http://107.21.149.43:8080/eventRegister/viewUpcomings");
            List<UpcomingEvent> response = await Task.Run(() =>
                                                          JsonConvert.DeserializeObject<List<UpcomingEvent>>(json));
            return response;
        }
    }
}
