using AWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWebAPIApp.Controllers
{
    public class AControllerController : ApiController
    {

        [HttpGet]
        public AResponseModel AnAction([FromUri] ARequestModel request) {
            // do something with request.AStringProperty

            return new AResponseModel {
                AGuidProperty = Guid.NewGuid(),
                AReversedStringProperty = new string(request.AStringProperty.ToCharArray().Reverse().ToArray())
            };
        }

    }
}
