using Newtonsoft.Json;
using PCLEStall.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace PCLEStall.ServiceConsumer
{
    public class ServiceConsumer
    {
        HttpClient client;
        //


        public ServiceConsumer(string baseUri)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
        }

        public ObservableCollection<Profile> GetProfile(string name = "")
        {
            HttpResponseMessage response = client.GetAsync(string.Concat("api/profile/", name)).Result;
            string profileJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ObservableCollection<Profile>>(profileJson);
        }

        public ObservableCollection<Profile> GetEmployersByProfile(string profile)
        {
            HttpResponseMessage response = client.GetAsync(string.Concat("api/employers/", profile)).Result;
            string profileJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ObservableCollection<Profile>>(profileJson);
        }

    }
}
