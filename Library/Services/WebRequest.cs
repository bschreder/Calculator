using Library.Business;
using Library.Interfaces;
using Library.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class WebRequest<T> : IWebRequest<T> where T : class
    {
        private static HttpClient _client = default(HttpClient);

        /// <summary>
        /// Assumes a HttpMethod.Post only interface
        /// </summary>
        /// <returns>http response</returns>
        public async Task<BResult<WebRequestResponse>> Request(WebRequestRequest<T> wrr)
        {
            if (_client == default(HttpClient))
                _client = new HttpClient();

            BResult<WebRequestResponse> result = new BResult<WebRequestResponse>
                    { Result = new WebRequestResponse() { ID = wrr.ID } };

            try
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, wrr.URL);
                foreach (KeyValuePair<string, string> h in wrr.Header)
                    httpRequestMessage.Headers.Add(h.Key, h.Value);
                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(wrr.Content), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(httpRequestMessage, wrr.CancellationToken);
                String responseContent = await response.Content.ReadAsStringAsync();
                result.Result.Content = responseContent;
                result.Result.StatusCode = response.StatusCode;
                result.Result.IsSuccessful = response.IsSuccessStatusCode;

                if (!response.IsSuccessStatusCode)
                    result.Result.ReasonPhrase = response.ReasonPhrase;
            }
            catch (Exception ex)
            {
                result.Error.Add(new HException("WebRequest", "Exception will executing HttpRequest", ex));
            }

            return result;
        }
    }
}
