
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : ApiController
    {
        [Route("api/service/SaveCustomer")]
        [ActionName("SaveCustomer")]
        [HttpPost]
        public string SaveCustomer([FromBody] JObject CusObj)
        {
            CustomerClass CusObj1 = new CustomerClass();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CusObj1 = serializer.Deserialize<CustomerClass>(CusObj.ToString());

            CusObj1.SaveCustomer(CusObj1);

            return " Saved Data sucsussfully";

        }
    }
}