using CEMIS.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Business.Central.Interface
{
    public interface IUserManagementServices
    {

        //User Object
        Task<IEnumerable<UsersObject>> GetUsers();
        Task<UsersObject> GetUser(long id);
        Task<bool> CreateUserAsync(UsersObject obj);
        Task<bool> UpdateUserAsync(UsersObject obj, long id);
        Task<bool> ActivateUserProtected(long Id, bool status);
        bool CheckEmailValidity(string email);
        //bool DeleteRIUser(InstUserObject obj);     
    }
}

