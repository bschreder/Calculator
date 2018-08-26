using Calculator.Business;
using Calculator.Models;
using Library.Business;
using System.Threading.Tasks;
using System.Web.Http;

namespace Calculator.Controllers
{
    public class MathController : ApiController
    {

        public async Task<IHttpActionResult> Post([FromBody]CalculatorRequest request)
        {
            BResult<CalculatorResponse> result = await new CalculateProcessor().ExecuteAsync(request);
            return ResponseMessage(new ActionResponse<CalculatorResponse>().CreateResponse(result));
        }
    }
}