using App20.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App20.Services
{
    public class EntrylistApiService
    {
        private readonly System.Net.Http.HttpClient client;

        #region Properties
        public List<EntryModel> Result { get; set; }
        public string WebAPIUrl { get; set; }
        public DialogueService DisplayBox;

        #endregion
        public EntrylistApiService()
        {
            client = new System.Net.Http.HttpClient();

        }

        #region APICall

        // Method for API Call
        public async Task<List<EntryModel>> GetDataAsync(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<EntryModel>>(content);
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
