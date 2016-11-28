using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AspMinimal.Controllers
{
    internal class ResponseMessageFactory
    {
        public static HttpResponseMessage Create(object value, System.Net.HttpStatusCode statusCode)
        {
            var resp = new HttpResponseMessage()
            {
                // Todo: Probably handle this exception if this ends up being used in something other than a PoC.
                Content = new StringContent(JsonConvert.SerializeObject(value))
            };

            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            resp.StatusCode = statusCode;
            return resp;
        }
    }

    public class AppController : ApiController
    {
        [Route("")]
        [HttpGet]
        public object RootPath()
        {
            var payload = new { message = "Hello from / (root path)" };
            return ResponseMessageFactory.Create(payload, System.Net.HttpStatusCode.OK);
        }

        [Route("session/")]
        [HttpGet]
        public object BetSlips()
        {
            var payload = new { message = "Hello from /session" };
            return ResponseMessageFactory.Create(payload, System.Net.HttpStatusCode.OK);
        }

        [Route("bet_slips/finalise")]
        [HttpGet]
        public object BetSlipsFinalise()
        {
            var payload = new { message = "Hello from /bet_slips/finalise" };
            return ResponseMessageFactory.Create(payload, System.Net.HttpStatusCode.OK);
        }

        [Route("betting/")]
        [HttpGet]
        public object Betting()
        {
            var payload = new { message = "Hello from /betting" };
            return ResponseMessageFactory.Create(payload, System.Net.HttpStatusCode.OK);
        }

        [Route("betting/notice")]
        [HttpGet]
        public object BettingNotice()
        {
            var payload = new { message = "Hello from /betting/notice" };
            return ResponseMessageFactory.Create(payload, System.Net.HttpStatusCode.OK);
        }
    }
}