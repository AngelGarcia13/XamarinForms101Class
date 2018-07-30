using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using PrismSeries.Models;

namespace PrismSeries.Services
{
    public class SeriesService : ISeriesService
    {
        public async System.Threading.Tasks.Task<IEnumerable<Serie>> GetAllSeriesAsync()
        {
            var result = new List<Serie>();
            try
            {
                using (var client = new HttpClient())
                {
                    var stringResponse = await client.GetStringAsync("https://api.trackseries.tv/v1/Stats/TopSeries/");
                    result = JsonConvert.DeserializeObject<List<Serie>>(stringResponse);
                }
            }
            catch (Exception ex)
            {
                //TODO: Logear exc...
                //throw;
            }
            
            return result;
        }
    }
}
