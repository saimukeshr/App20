using App20.Helpers;
using App20.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
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
                using (var httpClient = new HttpClient())
                {
                    var resultJson = await httpClient.GetStringAsync(url);
                     Result = JsonConvert.DeserializeObject<List<EntryModel>>(resultJson);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return Result;
        }

        public async Task<List<EntryModel>> PostDataAsync(EntryModel detail)
        {
            try
            {
                var Content = JsonConvert.SerializeObject(detail);
                var stringContent = new StringContent(Content, UnicodeEncoding.UTF8, "application/json");
                var result = await client.PostAsync("https://localhost:44327/listitems", stringContent);
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

        public async Task<List<EntryModel>> DeleteDataAsync(int Id)
        {
            try
            {
                var result = await client.DeleteAsync("https://localhost:44327/listitems/" + Id);
                if (result.IsSuccessStatusCode)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Data Deleted Succcessfully", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Data Deletion is not done", "Ok");
                }

            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<List<EntryModel>> UpdateDataAsync(EntryModel Data)
        {
            try
            {
                int id = Data.AlbumId;
                var Content = JsonConvert.SerializeObject(Data);
                var stringContent = new StringContent(Content, UnicodeEncoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:44327/listitems/"+ id, stringContent);
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

