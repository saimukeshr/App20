using App20.Models;
using App20.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App20.Services
{
    public class JsonServices
    {
        public List<Details> result1 { get; set; }

        // Method for Calling Json Data from local file
        public async Task<List<Details>> CallJsonDataAsync()
        {
            string jsonFileName = "OrderDetailsData.json";
            OrderObject OrderList = new OrderObject();
            var assembly = typeof(ListPageViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = await reader.ReadToEndAsync();
                OrderList = JsonConvert.DeserializeObject<OrderObject>(jsonString);
                result1 = OrderList.Info;
            }
            return result1;
        }
    }
}
