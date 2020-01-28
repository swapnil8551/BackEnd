using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTelecom.Models;

namespace OnlineTelecom.RepositoryLibrary.IRepository
{
    interface IUserRepository
    {
        T_Users SignIn(string Email, string Password);
        bool Register(T_Users User);
        bool Signout(string Email);
        T_Users IsUserExist(string emailId);
        bool isValidateOTP(string OTP, string email);
        bool ResetPassword(string Password, string email);
    }
}
