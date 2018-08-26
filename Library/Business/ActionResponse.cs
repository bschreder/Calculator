using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Library.Business
{
    public class ActionResponse<T> where T : class, new()
    {
        public HttpResponseMessage CreateResponse(BResult<T> result)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");

            if (result.Error.Count == 0)
            {
                if (result.Result == null || result.Result == default(T))
                    response.StatusCode = HttpStatusCode.NoContent;
                else
                    response.StatusCode = HttpStatusCode.OK;
            }
            else
                response.StatusCode = HttpStatusCode.BadRequest;

            return response;
        }


        public HttpResponseMessage CreateResponse(BResult result)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");

            if (result.Error.Count == 0)
                    response.StatusCode = HttpStatusCode.NoContent;
            else
                response.StatusCode = HttpStatusCode.BadRequest;

            return response;
        }
    }
}
