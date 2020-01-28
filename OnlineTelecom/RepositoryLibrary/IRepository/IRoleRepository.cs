using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTelecom.Models;

namespace OnlineTelecom.RepositoryLibrary.IRepository
{
    interface IRoleRepository
    {
        bool AddRole(T_Roles role);
        bool UpdateRole(T_Roles role);
        bool DeleteRole(int id);
        List<T_Roles> GetRole();
    }
}
