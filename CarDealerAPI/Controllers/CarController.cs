using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealerAPI.Controllers
{
    public class CarController : ApiController
    {
        [HttpGet]
        public JObject GetAllCars()
        {
            JObject jObject = new JObject();
            jObject["Hello"] = "Test";
            jObject["Test"] = "Hello";
            JArray temp = new JArray();
            jObject["Hmm"] = new JArray();

            
            //jObject["Hmm"][0] = "Test";

            return jObject;
        }
    }
}
