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
    public class ProductController : ApiController
    {
        [Route("api/service/SaveProduct")]
        [ActionName("SaveProduct")]
        [HttpPost]
        public string SaveCustomer([FromBody] JObject ProObj)
        {
            Product ProdObj1 = new Product();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProdObj1 = serializer.Deserialize<Product>(ProObj.ToString());

            ProdObj1.SaveProduct(ProdObj1);

            return " Saved Data sucsussfully";

            

        }

        [Route("api/service/LoadAllProduct")]
        [ActionName("LoadAllProduct")]
        [HttpPost]
        public object LoadAllProduct()
        {
            List<Product> listPro = new List<Product>();

            try
            {
                Product obj1 = new Product();
                listPro = obj1.LoadAllProduct();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listPro;

        }
    }
}