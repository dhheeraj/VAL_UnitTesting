using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HTTPClientClass
    {
        public HTTPClientClass() { }    
        public async Task<bool> IsUserAuthorized(string queryText,string accessToken, HttpClient client)
        {
            if (client == null) return false;
            try
            {
                using (var outgoingRequest = new HttpRequestMessage(HttpMethod.Get, queryText))
                {
                    outgoingRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    outgoingRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await client.SendAsync(outgoingRequest))
                    {
                        if (response.StatusCode == HttpStatusCode.Unauthorized) return false;

                        var res = await response.Content.ReadAsStringAsync();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {                
                throw;
            }

        }
    }
}
