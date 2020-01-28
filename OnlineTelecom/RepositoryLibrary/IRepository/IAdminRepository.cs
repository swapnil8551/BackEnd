using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTelecom.Models;

namespace OnlineTelecom.RepositoryLibrary.IRepository
{
    interface IAdminRepository
    {
        List<T_Users> GetUsers();
        bool AddHistory(T_PasswordHistoryLog history);
    }
}
