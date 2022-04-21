using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlightPlanning_UTSA
{
    class Client
    {
        public async Task<string> getMetarInfo(string icaoCode)
        {
            string BaseUrl = "https://api.met.no/weatherapi/tafmetar/1.0/metar?&icao=";

            string url = BaseUrl + icaoCode;

            var httpClient = HttpClientFactory.Create();

            var data = await httpClient.GetStringAsync(url);

            String[] liste = data.Split('=');

            int number = Convert.ToInt32(liste.Length);

            int lastString = number - 2;

            string METARINFO = liste[lastString];

            return METARINFO;

        }
    }
}
