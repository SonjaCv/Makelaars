using FundaAssignment.Entities.Models;
using FundaAssignment.Entities.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FundaAssignment.Services
{
    public class PropertiesService : IPropertiesService
    {
        static HttpClient client = new HttpClient();
        public PropertiesService()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
        }

        public async Task<List<Makelaar>> GetTopMakelaarsByCity(string city, bool hasGarden)
        {
            var makelaars = new List<Makelaar>();

            var baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            var apiKey = ConfigurationManager.AppSettings["apiKey"];

            var uri = string.Format("feeds/Aanbod.svc/json/{0}/?type=koop&zo=/{1}", apiKey, city);

            //include houses with tuin
            if (hasGarden)
            {
                uri += string.Format("/tuin");
            }
            HttpResponseMessage response = await client.GetAsync(baseUrl + uri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var properties = JsonConvert.DeserializeObject<Properties>(result);

                //Group the housing properties by Makelaar Id and select the list of properties they sell. Order the list of 
                //makelaars in descending order by count of properties they sell
                makelaars = properties.Objects.GroupBy(
                                    p => p.MakelaarId,
                                    (key, g) => new Makelaar
                                    {
                                        MakelaarId = key,
                                        MakelaarName = g.Select(mn => mn.MakelaarNaam).FirstOrDefault(),
                                        PropertiesCount = g.Count(),
                                        PropertyDetails = g.Select(pd => new PropertyDetails
                                        {
                                            Tagline = pd.PromoLabel.Tagline,
                                            RibbonText = pd.PromoLabel.RibbonText,
                                            Woonplaats = pd.Woonplaats,
                                            AntalKamers = pd.AntalKamers,
                                            Adres = pd.Adres
                                        }).ToList()
                                    }
                                    )
                                    .OrderByDescending(m => m.PropertiesCount)
                                    .Take(10).ToList();
            }

            return makelaars;
        }       
    }
}
