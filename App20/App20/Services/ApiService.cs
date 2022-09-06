using App20.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace App20.Services
{
    public class ApiService
    {
        System.Net.Http.HttpClient client;

        #region Properties
        public List<Details> result { get; set; }
        public string WebAPIUrl { get; set; }
        public DialogueService DisplayBox;

        #endregion
        public ApiService()
        {
            client = new System.Net.Http.HttpClient();

        }

        #region APICall

        // Method for API Call
        public async Task<List<Details>> GetDataAsync(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Details>>(content);
                    return result;
                }
                else
                    DisplayBox.DialogueBox("Alert", "Connection is not set", "Ok");
               
            }
            catch (Exception)
            {
            }
            return null;
        }

        #endregion
    }
}
