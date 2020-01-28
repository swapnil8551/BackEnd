using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineTelecom.Models;
using OnlineTelecom.RepositoryLibrary.IRepository;
using OnlineTelecom.RepositoryLibrary;

namespace OnlineRecharge.RepositoryLibrary
{
    public class UserRepository : IUserRepository
    {

        OnlineCarBookingEntities Dbobj;
        public UserRepository()
        {
            Dbobj = new OnlineCarBookingEntities();
        }
        public bool Save()
        {
            Dbobj.SaveChanges();
            return true;
        }

        public T_Users IsUserExist(string EmailId)
        {
            var data = (from t in Dbobj.T_Users
                        where t.EmailId == EmailId
                        select t).SingleOrDefault();
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        public string GenerateOTP(T_Users value)
        {
            OTPGenration otp = new OTPGenration();
            string generatedotp = otp.GetOTP("1", 5);
            sendOTP som = new sendOTP();
            T_OTP_Details otpdetails = new T_OTP_Details();
            otpdetails.UserId = value.UserId;
            otpdetails.OTP = generatedotp;
            otpdetails.GenratedOn = DateTime.Now;
            otpdetails.ValidTill = DateTime.Now.AddMinutes(5);
           // otpdetails.IsExpired = false;
            Dbobj.T_OTP_Details.Add(otpdetails);
            Dbobj.SaveChanges();
            return som.SendMail(value.EmailId, "Password reset", generatedotp);

        }
        public bool isValidateOTP(string OTPTyped, string email)
        {
            var data = (from optdtls in Dbobj.T_OTP_Details
                        where optdtls.OTP == OTPTyped && optdtls.T_Users.EmailId == email
                        && optdtls.ValidTill > DateTime.Now
                        select optdtls).SingleOrDefault();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ResetPassword(string password, string email)
        {
            var data = (from u in Dbobj.T_Users
                        where u.EmailId == email
                        select u).SingleOrDefault();
            if (data != null)
            {
                data.Password = password;
                Dbobj.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public T_Users SignIn(string Email, string Password)
        {
            try
            {
                T_Users User = Dbobj.T_Users.ToList().Where(u => u.EmailId == Email && u.Password == Password).SingleOrDefault();
                User.IsOnline = true;
                Save();
                return User;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Register(T_Users User)
        {
            try
            {
                if (User != null)
                {
                    Dbobj.T_Users.Add(User);
                    Save();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
                throw new Exception("Registration Failed");
            }
        }

        public bool SignOut(string Email)
        {
            try
            {
                T_Users User = Dbobj.T_Users.ToList().Where(u => u.EmailId == Email).SingleOrDefault();
                User.IsOnline = false;
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Signout(string Email)
        {
            throw new NotImplementedException();
        }
    }
}