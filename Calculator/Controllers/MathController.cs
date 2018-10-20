using Calculator.Business;
using Calculator.Models;
using Library.Business;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Calculator.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class MathController : ApiController
    {

        public async Task<IHttpActionResult> Post([FromBody]CalculatorRequest request)
        {
            BResult<CalculatorResponse> result = await new CalculateProcessor().ExecuteAsync(request);
            return ResponseMessage(new ActionResponse<CalculatorResponse>().CreateResponse(result));
        }
    }
}