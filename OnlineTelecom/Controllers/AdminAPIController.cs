using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineTelecom.Models;

namespace OnlineTelecom.Controllers
{
    public class AdminAPIController : ApiController
     
    {
        Response response = new Response();
        OnlineCarBookingEntities dalobj = new OnlineCarBookingEntities();
        // GET: api/AdminAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AdminAPI/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        [System.Web.Http.Route("api/AdminAPI/Map")]
        public Response post([FromBody]T_JourneyDetail j)
        {
            if(j!=null)
            {
                //j.UserId = 4;
                j.FareperKM = 5;
                j.TotalFare = j.TotalDistance*5;
                dalobj.T_JourneyDetail.Add(j);
                dalobj.SaveChanges();
                response.Error = null;
                response.Status = "Successfully";
                return response;
            }
            else
            {
                response.Error = null;
                response.Status = "Failed";
                return response;
            }


        }

        // PUT: api/AdminAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AdminAPI/5
        public void Delete(int id)
        {
        }
    }
}
