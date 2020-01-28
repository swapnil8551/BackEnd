using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineTelecom.Models;

namespace OnlineTelecom.Controllers
{
    public class CabDetailsController : ApiController
    {
        OnlineCarBookingEntities dalobj = new OnlineCarBookingEntities();
        Response response = new Response();

        
        [HttpGet]
        [Route("api/CabDetails/cabdetails")]
        public Response Get()
        {
            var listuser = dalobj.T_CabDetails.ToList();
            if (listuser != null)
            {
                response.Data = listuser;
                response.Error = null;
                response.Status = "Success";
                return response;
            }
            else
            {
                response.Error = null;
                response.Status = "No user Found..";
                return response;
            }
        }

        // GET: api/CabDetails/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CabDetails
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CabDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CabDetails/5
        public void Delete(int id)
        {
        }
    }
}
