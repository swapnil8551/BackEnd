using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineTelecom.Models;
using System.Net.Mail;
using System.Web;
using System.Net.Http.Formatting;


namespace OnlineTelecom.Controllers
{
    public class UserController : ApiController
    {
        OnlineCarBookingEntities dalObj = new OnlineCarBookingEntities();
        Response response = new Response();

        public UserController()
        {
            dalObj.Configuration.ProxyCreationEnabled = false;
        }
       
        // GET: api/User
        [HttpGet]
        [Route("api/User/get")]
        public Response Get()
        {
            
            var listuser = dalObj.T_Users.ToList();
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

        // GET: api/User/5
        public Response Get(int id)
        {
            Response response = new Response();
            T_Users u = dalObj.T_Users.Find(id);
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

        [HttpPost]
        [Route("api/User/Registration")]
        public Response Resgistration([FromBody]T_Users u)
        {
            
            if (u != null)
            {
                //u.RoleId = 3;
                dalObj.T_Users.Add(u);
                dalObj.SaveChanges();
                response.Error = null;
                response.Status = "User Register Successfully...";
                return response;
            }
            else
            {
                response.Error = null;
                response.Status = "Please enter valid data..";
                return response;
            }
        }

        [HttpPost]
        [Route("api/User/Login")]
        public Response Login([FromBody]T_Users u)
        {

            Response response = new Response();

            if (u.EmailId != null && u.Password != null)
            {
                var listuser = dalObj.T_Users.ToList();
                T_Users validuser = (from user in listuser
                                     where user.EmailId == u.EmailId &&
                                     user.Password == u.Password
                                     select user).SingleOrDefault();
                if (validuser != null)
                {
                    response.Data = validuser;
                    response.Error = null;
                    response.Status = "Success";
                    return response;
                }
                else
                {
                    response.Error = null;
                    response.Status = "Incorrect Credintial";
                    return response;
                }
            }
            else
            {
                response.Error = null;
                response.Status = "Field are empty";
                return response;
            }
        }
        // PUT: api/User/5
        public void Put(int id, [FromBody]T_Users u)
        {
            T_Users u1 = dalObj.T_Users.Find(id);
            u1.Name = u.Name;
            u1.EmailId = u.EmailId;
            u1.Password = u.Password;
            u1.MobileNo = u.MobileNo;
            u1.IsOnline = u.IsOnline;
            u1.IsLocked = u.IsLocked;
            u1.RoleId = u.RoleId;
            dalObj.SaveChanges();
        }

        // DELETE: api/User/5
        public Response Delete(int id)
        {
            Response response = new Response();

            dalObj.T_Users.Remove(dalObj.T_Users.Find(id));
            dalObj.SaveChanges();
            response.Error = null;
            response.Status = "User Deleted Successfully...";
            return response;

        }

        [HttpPost]
        [Route("api/User/post")]
        public Response post([FromBody] Email e)
        {
            Response rs = new Response();
            string to = e.to;
            string body = e.body;
            string subject = e.subject;

            string result = "Message Sent Successfully..!!";
            string senderID = "swapdhoble@gmail.com";// use sender’s email id here..
            const string senderPassword = "swapnil9270"; // sender password here…
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderID, to, subject, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
                rs.Error = ex;
            }
            return rs;
        }


        [HttpPut]
        [Route("api/User/")]
        public Response UpdateUser([FromBody]T_Users user)
        {
            var userlist = dalObj.T_Users.ToList();
            var usertoupdate = (from u in userlist
                                where u.UserId == user.UserId
                                select u).SingleOrDefault();
            if(usertoupdate!=null)
            {
                usertoupdate.UserId = user.UserId;
                usertoupdate.EmailId = user.EmailId;
                usertoupdate.Name = user.Name;
                usertoupdate.Password = user.Password;
                usertoupdate.MobileNo = user.MobileNo;
                usertoupdate.UserId = 3;
                dalObj.SaveChanges();
                response.Status = "Success";
                response.Error = null;
                response.Data = usertoupdate;
                return response;

            }
            else
            {
                response.Status = "Failed";
                response.Error = null;
                response.Data = null;
                return response;
            }
        }

    }
}
