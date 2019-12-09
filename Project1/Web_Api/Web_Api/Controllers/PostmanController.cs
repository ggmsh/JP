using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Scheduler.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Web_Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PostmanController : ControllerBase
    {
        public string AuthResponse(string id,string pass)
        {
            if (id == "ggmsh" && pass == "asd123")
            {
                var obj1 = new JObject();
                obj1["Response"] = "authenticated : true";
                obj1["methodType"] = "Authentication";
                return obj1.ToString();
            }

            var obj = new JObject();
            obj["Response"] = "Unauthrised;";
            return obj.ToString();

        }

        [Route("auth")]
        public string Authentication(string id,string pass)
        {
            return AuthResponse(id,pass);
            /*
             System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
             string token = string.Empty;
             string pwd = string.Empty;
             if (headers.Contains("username"))
         {
             token = headers.GetValues("username").First();
         }
           if (headers.Contains("password"))
        {
           pwd = headers.GetValues("password").First();
        }
         //code to authenticate and return some thing
           if (!Authenticated(token, pwd)
              return Unauthorized();
             */
        }

        public List<string> Response(string res,string type)
        {
            List<string> list = new List<string>();
            var obj = new JObject();
            obj["Response"] = res;
            obj["methodType"] = type;
            list.Add(obj.ToString());
            return list;
        }
        // GET: api/Postman
        [Route("get")]
        [HttpGet]
        public List<string> Get(string arg)
        {
            return Response(arg,"Get");
        }


        // POST: api/Postman
        [Route("post")]
        [HttpPost]
        public List<string> Post(string value)
        {
            return Response(value,"Post");
        }

        [Route("postformdata")]
        [HttpPost]
        public List<string> PostFormData(string value)
        {
            return Response(value, "PostFormData");
        }

        // PUT: api/Postman/5
        [Route("put")]
        [HttpPut]
        public List<string> Put(string value)
        {
            return Response(value, "Put");
        }

        [Route("patch")]
        [HttpPatch("{id}")]
        public List<string> Patch(string value)
        {
            return Response(value, "Patch");
        }

        // DELETE: api/ApiWithActions/5
        [Route("delete")]
        [HttpDelete]
        public List<string> Delete(string value)
        {
            return Response(value, "delete");
        }


        [Route("request")]
        [HttpPost]
        public List<string> RequestHeader(string request)
        {
            return Response(request, "RequestHeader");
        }

        [Route("response")]
        [HttpGet]
        public List<string> ResponseHeader(string response)
        {
            return Response(response, "ResponseHeader");
        }


    }
}

//namespace Web_Api
//{
//    class HttpAuthentication : Attribute
//    {
//    }
//}