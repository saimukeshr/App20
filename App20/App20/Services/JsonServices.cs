using App20.Models;
using App20.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App20.Services
{
    public class JsonServices
    {
        public List<Details> Result1 { get; set; }

        // Method for Calling Json Data from local file
        public async Task<List<Details>> CallJsonDataAsync(string jsonfilename)
        {
            try
            {
                string jsonFileName = jsonfilename;
                OrderObject OrderList = new OrderObject();
                var assembly = typeof(ListPageViewModel).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
                using (StreamReader reader = new StreamReader(stream))
                {
                    string jsonString = await reader.ReadToEndAsync();
                    OrderList = JsonConvert.DeserializeObject<OrderObject>(jsonString);
                    Result1 = OrderList.Info;
                }
               
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return Result1;
        }

       
    }
}
