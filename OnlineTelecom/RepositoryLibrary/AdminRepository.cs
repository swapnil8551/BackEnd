using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OnlineTelecom.Models;
using OnlineTelecom.RepositoryLibrary.IRepository;

namespace OnlineTelecom.RepositoryLibrary
{
    public class AdminRepository : ApiController
    {
        OnlineCarBookingEntities dalObj;
       

        public AdminRepository()
        {
            dalObj = new OnlineCarBookingEntities();
        }
        public List<T_PasswordHistoryLog> GetHistory()
        {
            try
            {
                return dalObj.T_PasswordHistoryLog.ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public List<T_Users> GetUser()
        {
            try
            {
                return dalObj.T_Users.ToList();
            }
            catch(Exception)
            {
                throw;
            }           
        }
        public bool AddRole(T_Roles role)
        {
            try
            {
                dalObj.T_Roles.Add(role);
                dalObj.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public bool AddHistory(T_PasswordHistoryLog history)
        //{
        //    try
        //    {
        //        history.ChangedOn

        //    }
        //    catch(Exception)
        //    {

        //    }
        //}
    }
}