using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Business.Interface
{
   public interface IPasswordService
    {
        //User Default Password Services
        IEnumerable<TCoreUsersPasswordObject> GetUserDefaultPasswordsById(int? id);
        IEnumerable<TCoreUsersPasswordObject> GetUserDefaultPasswords(int id);
       Task <TCoreUsersPasswordObject> GetUserDefaultPassword(long? id);
        TCoreUsersPasswordObject GetUserDefaultPasswordByProfile(int? userId);
       // void IncUserDefaultPasswordInvalidLogin(int? userId, int? Invalid, string UserName);
       // void IncUserDefaultPasswordSuccessfulLogin(TCoreUsersPasswordObject obj);
       // void IncUserDefaultPasswordCumulativeLogin(int? userId, int? Cumulative, string UserName);
        Task CreateUserDefaultPassword(UsersPassword obj);
        bool UpdateUserDefaultPassword(TCoreUsersPasswordObject obj);
        bool MailingPassword(TCoreUsersPasswordObject obj);
        bool DeleteUserDefaultPassword(TCoreUsersPasswordObject obj);

        //User Old Password Services
       // IEnumerable<TCoreUsersPasswordHistObject> GetUserOldPasswords(int? id);
        UsersPasswordHistObject GetUserOldPassword(int? id);
        //TCoreUsersPasswordHistObject GetUserOldPasswordByProfile(int? userId);
        void CreateUserOldPassword(UsersPasswordHistObject obj);
        bool UpdateUserOldPassword(UsersPasswordHistObject obj);
        bool DeleteUserOldPassword(UsersPasswordHistObject obj);
        ////User Default Password Services
        //IEnumerable<TCoreUsersPasswordObject> GetUserDefaultPasswordsById(int? id);
        //IEnumerable<TCoreUsersPasswordObject> GetUserDefaultPasswords(int id);
        //TCoreUsersPasswordObject GetUserDefaultPassword(int? id);
        //TCoreUsersPasswordObject GetUserDefaultPasswordByProfile(int? userId);
        //void IncUserDefaultPasswordInvalidLogin(int? userId, int? Invalid, string UserName);
        //void IncUserDefaultPasswordSuccessfulLogin(TCoreUsersPasswordObject obj);
        //void IncUserDefaultPasswordCumulativeLogin(int? userId, int? Cumulative, string UserName);
        //void CreateUserDefaultPassword(TCoreUsersPasswordObject obj);
        //bool UpdateUserDefaultPassword(TCoreUsersPasswordObject obj);
        //bool MailingPassword(TCoreUsersPasswordObject obj);
        //bool DeleteUserDefaultPassword(TCoreUsersPasswordObject obj);

        ////User Old Password Services
        //IEnumerable<TCoreUsersPasswordHistObject> GetUserOldPasswords(int? id);
        //TCoreUsersPasswordHistObject GetUserOldPassword(int? id);
        //TCoreUsersPasswordHistObject GetUserOldPasswordByProfile(int? userId);
        //void CreateUserOldPassword(TCoreUsersPasswordHistObject obj);
        //bool UpdateUserOldPassword(TCoreUsersPasswordHistObject obj);
        //bool DeleteUserOldPassword(TCoreUsersPasswordHistObject obj);


    }
}
