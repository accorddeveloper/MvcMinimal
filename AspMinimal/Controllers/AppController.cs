using Newtonsoft.Json;
using System.Configuration;
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
        public static string VersionKey = "CurrentVersion";

        public HttpResponseMessage CreateResponse(string path)
        {
            var theHeaders = Request.Headers;
            var thePayload = new
            {
                message = string.Format("Hello from {0} v{1}", 
                path, ConfigurationManager.AppSettings.Get(VersionKey)),
                headers = theHeaders
            };

            return ResponseMessageFactory.Create(thePayload, System.Net.HttpStatusCode.OK);
        }

        [Route("")]
        [HttpGet]
        public object RootPath()
        {
            return CreateResponse("/ (root path)");
        }

        [Route("session/")]
        [HttpGet]
        public object Session()
        {
            return CreateResponse("/session");
        }

        [Route("bet_slips/finalise")]
        [HttpGet]
        public object BetSlipsFinalise()
        {
            return CreateResponse("/bet_slips/finalise");
        }

        [Route("betting/")]
        [HttpGet]
        public object Betting()
        {
            return CreateResponse("/betting");
        }

        [Route("betting/notice")]
        [HttpGet]
        public object BettingNotice()
        {
            return CreateResponse("/betting/notice");
        }
    }
}