﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App20.Helpers
{
    public class SimpleGraphService
    {
        public async Task<string> GetNameAsync()
        {
            using (var client = new HttpClient())
            {
                var token = await SecureStorage.GetAsync("AccessToken");

                if (!string.IsNullOrEmpty(token))
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me");
                    message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var response = await client.SendAsync(message);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = (JObject)JsonConvert.DeserializeObject(json);

                        if (data.ContainsKey("givenName"))
                            return data["givenName"].Value<string>();
                        else
                            return "Mr. No Name";
                        //currentUser = JsonConvert.DeserializeObject<User>(json);
                    }
                }
                else
                {
                    return "Token Invalid";
                }
            }

            return "Name unknown";
        }
    }
}
