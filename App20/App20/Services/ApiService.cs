using App20.Helpers;
using App20.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App20.Services
{
    public class ApiService
    {
        public readonly HttpClient client;

        #region Properties
        public List<Details> Result { get; set; }
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

        public async Task<List<Details>> PostDataAsync(Details detail)
        {
            try
            {
                var Content = JsonConvert.SerializeObject(detail);
                var stringContent = new StringContent(Content, UnicodeEncoding.UTF8, "application/json");
                var result = await client.PostAsync(ApiHelper.listviewurl, stringContent);
                if (result.IsSuccessStatusCode)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Data Saved Succcessfully", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Data is not Saved", "Ok");
                }

            }
            catch (Exception) 
            {
            }
             return null; 
        }

        public async Task<List<Details>> DeleteDataAsync(int OrderId)
        {
            try
            { 
                 var result = await client.DeleteAsync(ApiHelper.listviewurl + OrderId);
                //var responsebody = await result.Content.ReadAsStringAsync();
                //var response = JsonConvert.DeserializeObject<bool>(responsebody);
                //return response;
                if (result.IsSuccessStatusCode)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Data Deleted Succcessfully", "Ok");
                }

            }
            catch (Exception)
            {
                
            }

            return null;
        }

        public async Task<List<Details>> UpdateDataAsync(Details detail)
        {
            try
            {
                var Content = JsonConvert.SerializeObject(detail);
                var stringContent = new StringContent(Content, UnicodeEncoding.UTF8, "application/json");
                var result = await client.PutAsync(ApiHelper.listviewurl, stringContent);
                if (result.IsSuccessStatusCode)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Data Saved Succcessfully", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Data is not Saved", "Ok");
                }

            }
            catch (Exception)
            {
            }
            return null;
        }
        #endregion
    }
}
