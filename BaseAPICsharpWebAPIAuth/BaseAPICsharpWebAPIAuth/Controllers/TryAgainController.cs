using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseAPICsharpWebAPIAuth.Controllers
{
    public class TryAgainController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage seila()
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage funciona()
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}