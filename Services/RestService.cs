using MobileGuide.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Text;
using System.Threading.Tasks;

namespace MobileGuide.Services
{
    public class RestService : IRestService
    {
        private static HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(2);
        }

        public async Task<List<Restaurant>> FetchFoodMenu()
    {
            var query = "https://www.mocky.io/v2/5dfccffc310000efc8d2c1ad";
            var restaurant = new List<Restaurant>();
            try
            {
                var response = await ExecuteGetRequestAsync(query, "FetchFoodMenu");
                if (IsSuccess(response))
                {
                    var content = await response.Content.ReadAsStringAsync();
                    restaurant = JsonConvert.DeserializeObject<List<Restaurant>>(content);
                }
                else if (response != null && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                }
            }
            catch (Exception ex)
            {
            }
            return restaurant;
        }

        private async Task<HttpResponseMessage> ExecuteGetRequestAsync(String query, String callerMethod, HttpCompletionOption httpCompletionOption = HttpCompletionOption.ResponseContentRead)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                //You are offline, notify the user
                return null;
            }
            try
            {
                var response = await client.GetAsync(query, httpCompletionOption);
                if (IsSuccess(response))
                {
                    return response;
                }
                else if (response != null && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // TODO: Unauthorised implementation
                }
                else
                {
                    // TODO: implementation
                }
            }
            catch (Exception ex)
            {
                // TODO: Crashlitics or AppCenter implementation
            }
            return null;
        }

        private bool IsSuccess(HttpResponseMessage response)
        {
            bool retVal = false;

            if (response != null && response.IsSuccessStatusCode)
            {
                retVal = true;
            }
            return retVal;
        }

    }
}
