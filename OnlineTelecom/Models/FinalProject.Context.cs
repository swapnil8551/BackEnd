﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineTelecom.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class OnlineCarBookingEntities : DbContext
    {
        public OnlineCarBookingEntities()
            : base("name=OnlineCarBookingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<T_ErrorLogs> T_ErrorLogs { get; set; }
        public DbSet<T_OTP_Details> T_OTP_Details { get; set; }
        public DbSet<T_PasswordHistoryLog> T_PasswordHistoryLog { get; set; }
        public DbSet<T_Roles> T_Roles { get; set; }
        public DbSet<T_Users> T_Users { get; set; }
        public DbSet<T_JourneyDetail> T_JourneyDetail { get; set; }
        public DbSet<T_CabDetails> T_CabDetails { get; set; }
    
        public virtual int proc_AddRole(string roleName)
        {
            var roleNameParameter = roleName != null ?
                new ObjectParameter("RoleName", roleName) :
                new ObjectParameter("RoleName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_AddRole", roleNameParameter);
        }
    
        public virtual int proc_ModifyRole(Nullable<int> roleId, string roleName)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            var roleNameParameter = roleName != null ?
                new ObjectParameter("RoleName", roleName) :
                new ObjectParameter("RoleName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_ModifyRole", roleIdParameter, roleNameParameter);
        }
    
        public virtual int proc_RemoveRole(Nullable<int> roleId)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_RemoveRole", roleIdParameter);
        }
    }
}
