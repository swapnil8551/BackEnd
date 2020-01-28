using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineTelecom.Models;
using System.Data.Entity.Validation;

namespace OnlineTelecom.Controllers
{
    public class LoginController : ApiController
    {
        OnlineCarBookingEntities dalObj = new OnlineCarBookingEntities();

        public LoginController ()
        {
            dalObj.Configuration.ProxyCreationEnabled = false;
        }
        Response response = new Response();

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/Login/PassHistory")]
        public IEnumerable<T_PasswordHistoryLog> Get_data()
        {
            return ((dalObj.T_PasswordHistoryLog.ToList()));
        }


        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public Response Post([FromBody]T_Users data)
        {
            if(data.EmailId != null && data.Password !=null)
            {
                List<T_Users> user = dalObj.T_Users.ToList();
                T_Users validuser = (from u in user
                                     where u.EmailId == data.EmailId && u.Password == data.Password
                                     select u).SingleOrDefault();
                if(validuser !=null)
                {
                    response.Data = validuser;
                    response.Error = null;
                    response.Status = "Success";
                    return response;
                }
                else
                {
                
                    response.Error = null;
                    response.Status = "Invalid Data !!";
                    return response;

                }
                                     

            }
            else
            {
                response.Error = null;
                response.Status = "Fields are empty !!";
                return response;

            }
        }

        //register new user
            [HttpPost]
            [Route("api/Login/Registration")]
            public Response Registration(T_Users data)
             {
               Console.WriteLine(data);
               // data.RoleId = 2;
                dalObj.T_Users.Add(data);
                //dalobject.SaveChanges();
            try
            {
                dalObj.SaveChanges();
                response.Data = data;
                response.Error = null;
                response.Status = "Success";
                return response;
            }
            catch (DbEntityValidationException ex)
            {
                //foreach (var entityValidationErrors in ex.EntityValidationErrors)
                //{
                //    foreach (var validationError in entityValidationErrors.ValidationErrors)
                //    {
                //        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                //    }
                //}
                
                response.Data = null;
                response.Error = ex;
                response.Status = "Error";
                return response;
            }


        }

        [HttpPost]
        [Route("api/Login/OTP")]
        public Response OTP([FromBody]dynamic otpDetails)
        {
            string email = otpDetails.EmailId.ToString();


            var userlist = dalObj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == email
                        select u).SingleOrDefault();
            string o = otpDetails.OTP.ToString();

            var otpd = dalObj.T_OTP_Details.ToList();
            var vOTP = (from v in otpd
                        where v.UserId == User.UserId && v.OTP == o
                        select v).SingleOrDefault();

            if (vOTP != null)
            {
                Response RC = new Response();
                RC.Status = "success";
                RC.Error = null;
                RC.Data = vOTP;
                return RC;
            }
            else
            {
                Response RC = new Response();
                RC.Status = "fail";
                RC.Error = null;
                RC.Data = false;
                return RC;
            }
        }


        [HttpPost]
        [Route("api/Login/IsExist")]
        public Response IsExist([FromBody]T_Users value)
        {

            var userlist = dalObj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId
                        select u).SingleOrDefault();
            if (User != null)
            {
                Response RC = new Response();
                string mails = GetOTP();

                T_OTP_Details otp = new T_OTP_Details();
                otp.UserId = User.UserId;
                otp.ValidTill = DateTime.Now;
                otp.GenratedOn = DateTime.Now;
                otp.OTP = mails;
                dalObj.T_OTP_Details.Add(otp);
                dalObj.SaveChanges();


                RC.Status = "success";
                RC.Error = null;
                RC.Data = mails;
                return RC;
            }
            else
            {
                Response RC = new Response();
                RC.Status = "fail";
                RC.Error = null;
                RC.Data = false;
                return RC;
            }

        }

        [HttpPut]
        [Route("api/Login/UpdatePassword")]
        public Response updatepassword([FromBody]T_Users value)
        {

            var userlist = dalObj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId
                        select u).SingleOrDefault();

            if (User != null)
            {
                User.Password = value.Password;
                dalObj.SaveChanges();
                Response rc = new Response();
                rc.Status = "success";
                rc.Error = null;
                rc.Data = User;
                return rc;
            }
            else
            {
                Response rc = new Response();
                rc.Status = "fail";
                rc.Error = null;
                rc.Data = null;
                return rc;
            }
        }
        private string GetOTP(string otpType = "1", int len = 5)
        {
            //otptype 1 = alpha numeric
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            if (otpType == "1")
            {
                characters += alphabets + small_alphabets + numbers;
            }
            int length = 5;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }

        //// PUT: api/Login/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Login/5
        //public void Delete(int id)
        //{
        //    //dalobject.proc_RemoveRole(id);
        //}
    }
}
