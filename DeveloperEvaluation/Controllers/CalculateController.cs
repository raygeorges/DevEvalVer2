using DeveloperEvaluation.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace DeveloperEvaluation.Controllers
{
    /// <summary>
    /// Receives data from web client to calculate. Returns JSON response.
    /// </summary>
    public class CalculateController : ApiController
    {
        //Cheat a little with CORS here...

        // POST api/Calculate
        public JsonResult<CalculationDTO> Post([FromBody]IncomingDataDTO values)
        {
            return Json(new CalculationHelper(values).Calculate());
        }

    }
}