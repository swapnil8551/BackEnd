using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineTelecom.Models;

namespace OnlineTelecom.Controllers
{
    public class MapApiController : ApiController
    {
        OnlineCarBookingEntities dalObj = new OnlineCarBookingEntities();

        // GET: api/MapApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MapApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MapApi

        //    [HttpPost]
        //    [Route("api/MapApi/")]
        //public void Post()
        //{
        //}

        // PUT: api/MapApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MapApi/5
        public void Delete(int id)
        {
        }
    }
}
