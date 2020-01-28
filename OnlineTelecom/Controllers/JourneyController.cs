using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineTelecom.Models;
namespace OnlineTelecom.Controllers
{
    public class JourneyController : ApiController
    {
        OnlineCarBookingEntities dalobj = new OnlineCarBookingEntities();
        Response response = new Response();
        // GET: api/Journey
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Journey/5
        public Response Get(int id)
        {
            T_JourneyDetail u = dalobj.T_JourneyDetail.Find(id);
            if (u != null)
            {
                response.Data = u;
                response.Error = null;
                response.Status = "Success";
                return response;
            }
            else
            {
                response.Error = null;
                response.Status = "Enter valid Id ...";
                return response;
            }
        }

        // POST: api/Journey
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Journey/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Journey/5
        public void Delete(int id)
        {
        }
    }
}
