using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineTelecom.Models;
using OnlineTelecom.RepositoryLibrary;

namespace OnlineTelecom.RepositoryLibrary
{
    public class RoleRepository
    {
        OnlineCarBookingEntities dalobj = new OnlineCarBookingEntities();
        public  RoleRepository()
        {
            //FinalProject_DBEntities dalobj = new FinalProject_DBEntities();
        }
        public bool AddRole(T_Roles role)
        {
            try
            {
                dalobj.T_Roles.Add(role);
                dalobj.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool DeleteRole(int id)
        {
            try
            {
                T_Roles DRole = dalobj.T_Roles.Find(id);
                dalobj.T_Roles.Remove(DRole);
                dalobj.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<T_Roles> GetRole()
        {
            try
            {
                return dalobj.T_Roles.ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool UpadteRole(T_Roles role)
        {
            try
            {
                T_Roles URole = dalobj.T_Roles.Find(role.RoleId);
                URole.RoleName = role.RoleName;
                dalobj.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
       
    }
}