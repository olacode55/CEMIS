using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using CEMIS.Utility.ViewModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CEMIS.Business.Central.Services
{
    public class PasswordManangementServices : IPasswordService
    {
        private IRepository<UsersPassword> _userdefaultpasswordRepository;
        private IRepository<UsersPasswordHist> _useroldpasswordRepository;
        private IRepository<PasswordOptions> _passwordOptionRepository;
        private appContextCentral _context;
        private readonly IConfiguration _configura;


        public PasswordManangementServices(IRepository<UsersPassword> userdefaultpasswordRepository, IRepository<UsersPasswordHist> useroldpasswordRepository,
            IRepository<PasswordOptions> passwordOptionRepository, appContextCentral context, IConfiguration configura)
        {
            _userdefaultpasswordRepository = userdefaultpasswordRepository;
            _useroldpasswordRepository = useroldpasswordRepository;
            _passwordOptionRepository = passwordOptionRepository;
            _context = context;
            _configura = configura;
        }

        #region User Default Passwords
        public async Task CreateUserDefaultPassword(UsersPassword obj)
        {
            try
            {
                if (obj.PwdEncrypt != string.Empty)
                {
                    //var entity = Mapper.Map<TUserDefaultPasswordObject, TUserDefaultPassword>(obj);
                    UsersPassword entity = new UsersPassword
                    {
                        UserId = obj.UserId,
                        PwdEncrypt = obj.PwdEncrypt,
                        PwdExpiryDate = obj.PwdExpiryDate,
                        CumulativeLogins = obj.CumulativeLogins,
                        InvalidLogins = obj.InvalidLogins,
                        ForcePwdChange = obj.ForcePwdChange,
                        LockedOut = obj.LockedOut,
                        LastLogin = null,
                        PwdChangedDate = null,
                        LastModified = null,
                        CreatedBy = obj.CreatedBy,
                        //CreatedDate = obj.CreatedDate,
                        LockoutDate = null,
                        ModifiedBy = null,
                        
                        SuccessfulLogins = obj.SuccessfulLogins
                    };
                    await _userdefaultpasswordRepository.CreateAsync(entity);
                  

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CreateUserOldPassword(UsersPasswordHistObject obj)
        {
            try
            {
                if (obj.PwdEncrypt != string.Empty)
                {
                    obj.DateUpdated = DateTime.Now;


                    //var entity = Mapper.Map<TCoreUsersPasswordHistObject, UsersPasswordHist>(obj);
                    UsersPasswordHist entity = new UsersPasswordHist
                    {
                        CoreUserId = obj.UserId,
                        PwdCount = obj.PwdCount,
                        PwdEncrypt =obj.PwdEncrypt,
                        DateCreated = DateTime.Now,
                        CreatedBy = obj.CreatedBy,
                        UpdatedBy = obj.UpdatedBy,


                    };

                    _useroldpasswordRepository.Create(entity);
                   // _useroldpasswordRepository.sa();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete Password
        public bool DeleteUserDefaultPassword(TCoreUsersPasswordObject obj)
        {
            var entity = _context.coreUsersPasswords.Find(obj.UserId);
            try
            {
                if (entity != null)
                {
                    ///entity.IsDeleted = true;
                    entity.LastModified = DateTime.Now;
                    _userdefaultpasswordRepository.Update(entity);
                   // _userdefaultpasswordRepository.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteUserOldPassword(UsersPasswordHistObject obj)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region  Get Password
        public async Task<TCoreUsersPasswordObject> GetUserDefaultPassword(long? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var entity =await _context.coreUsersPasswords.FirstOrDefaultAsync(x => x.UserId == id);

                    TCoreUsersPasswordObject obj = new TCoreUsersPasswordObject
                    {
                        UserId = entity.UserId,
                        PwdEncrypt = entity.PwdEncrypt,
                        PwdExpiryDate = entity.PwdExpiryDate,
                        CumulativeLogins = entity.CumulativeLogins,
                        InvalidLogins = entity.InvalidLogins,
                        ForcePwdChange = entity.ForcePwdChange,
                        LockedOut = entity.LockedOut,
                        LastLogin = entity.LastLogin,
                        PwdChangedDate = entity.PwdChangedDate,
                       // LastModified = entity.LastModified,
                        CreatedBy = entity.CreatedBy,
                        //CreatedDate = entity.CreatedDate,
                        LockoutDate = entity.LockoutDate,
                        UpdatedBy = entity.UpdatedBy,
                        DateUpdated = entity.DateUpdated,
                        SuccessfulLogins = entity.SuccessfulLogins
                    };
                    return obj;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public TCoreUsersPasswordObject GetUserDefaultPasswordByUsername(long id)
        {
            try
            {
                //if (!string.IsNullOrEmpty(id))

                long getuser = _context.Users.Where(x => x.Id == id).Select(p => p.Id).Single();
                var entity = _context.coreUsersPasswords.Find(getuser);

                TCoreUsersPasswordObject obj = new TCoreUsersPasswordObject
                {
                    UserId = entity.UserId,
                    PwdEncrypt = entity.PwdEncrypt,
                    PwdExpiryDate = entity.PwdExpiryDate,
                    CumulativeLogins = entity.CumulativeLogins,
                    InvalidLogins = entity.InvalidLogins,
                    ForcePwdChange = entity.ForcePwdChange,
                    LockedOut = entity.LockedOut,
                    LastLogin = entity.LastLogin,
                    PwdChangedDate = entity.PwdChangedDate,
                    //LastModified = entity.LastModified,
                    CreatedBy = entity.CreatedBy,
                    //CreatedDate = entity.CreatedDate,
                    LockoutDate = entity.LockoutDate,
                    // ModifiedBy = entity.ModifiedBy,
                    SuccessfulLogins = entity.SuccessfulLogins
                };
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public TCoreUsersPasswordObject GetUserDefaultPasswordByProfile(int? userId)
        {

            try
            {
                if (userId.HasValue)
                {
                    var entity = _userdefaultpasswordRepository.Find(x => x.UserId == userId);
                    TCoreUsersPasswordObject obj = new TCoreUsersPasswordObject
                    {
                        UserId = entity.UserId,
                        PwdEncrypt = entity.PwdEncrypt,
                        PwdExpiryDate = entity.PwdExpiryDate,
                        CumulativeLogins = entity.CumulativeLogins,
                        InvalidLogins = entity.InvalidLogins,
                        ForcePwdChange = entity.ForcePwdChange,
                        LockedOut = entity.LockedOut,
                        LastLogin = entity.LastLogin,
                        PwdChangedDate = entity.PwdChangedDate,
                        DateUpdated = entity.DateUpdated,
                        CreatedBy = entity.CreatedBy,
                        DateCreated = entity.DateCreated,
                        LockoutDate = entity.LockoutDate,
                       // ModifiedBy = entity.ModifiedBy,
                        SuccessfulLogins = entity.SuccessfulLogins
                    };
                    //var entity = Mapper.Map<TUserDefaultPassword, TUserDefaultPasswordObject>(entity);
                    return obj;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TCoreUsersPasswordObject> GetUserDefaultPasswords(int id)
        {
            try
            {
                //var entities = _userdefaultpasswordRepository.Get(x => x.LockedOut == true, x => x.OrderBy(y => y.LastModified),null);
                //var entities = _userdefaultpasswordRepository.Get(p => p.UserId == id, x => x.OrderBy(y => y.LastModified), null);
                var entities = _userdefaultpasswordRepository.All().Where(p => p.UserId == id).OrderBy(p => p.LastModified);
                IList<TCoreUsersPasswordObject> List = new List<TCoreUsersPasswordObject>();
                foreach (var entity in entities)
                {
                    TCoreUsersPasswordObject obj = new TCoreUsersPasswordObject
                    {
                        UserId = entity.UserId,
                        PwdEncrypt = entity.PwdEncrypt,
                        PwdExpiryDate = entity.PwdExpiryDate,
                        CumulativeLogins = entity.CumulativeLogins,
                        InvalidLogins = entity.InvalidLogins,
                        ForcePwdChange = entity.ForcePwdChange,
                        LockedOut = entity.LockedOut,
                        LastLogin = entity.LastLogin,
                        PwdChangedDate = entity.PwdChangedDate,
                       // LastModified = entity.LastModified,
                        CreatedBy = entity.CreatedBy,
                      //  CreatedDate = entity.CreatedDate,
                        LockoutDate = entity.LockoutDate,
                       // ModifiedBy = entity.ModifiedBy,
                        SuccessfulLogins = entity.SuccessfulLogins
                    };
                    //var obj = Mapper.Map<TUserDefaultPassword, TUserDefaultPasswordObject>(entity);
                    //obj.User = entity.Staff.FirstName + " " + entity.Staff.MiddleName + " " + entity.Staff.SurName;
                    List.Add(obj);
                }
                return List.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool MailingPassword(TCoreUsersPasswordObject obj)
        {
            try
            {
                var entity = _context.coreUsersPasswords.Find(obj.UserId);
                if (entity != null)
                {
                    entity.LastModified = DateTime.Now;
                    _userdefaultpasswordRepository.Update(entity);
                    //_userdefaultpasswordRepository.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<TCoreUsersPasswordObject> GetUserDefaultPasswordsById(int? id)
        {
            try
            {
                var entities = _userdefaultpasswordRepository.All().Where(x => x.UserId == id);
                IList<TCoreUsersPasswordObject> List = new List<TCoreUsersPasswordObject>();
                foreach (var entity in entities)
                {
                    TCoreUsersPasswordObject obj = new TCoreUsersPasswordObject
                    {
                        UserId = entity.UserId,
                        PwdEncrypt = entity.PwdEncrypt,
                        PwdExpiryDate = entity.PwdExpiryDate,
                        CumulativeLogins = entity.CumulativeLogins,
                        InvalidLogins = entity.InvalidLogins,
                        ForcePwdChange = entity.ForcePwdChange,
                        LockedOut = entity.LockedOut,
                        LastLogin = entity.LastLogin,
                        PwdChangedDate = entity.PwdChangedDate,
                       // LastModified = entity.LastModified,
                        CreatedBy = entity.CreatedBy,
                        //CreatedDate = entity.CreatedDate,
                        LockoutDate = entity.LockoutDate,
                        //ModifiedBy = entity.ModifiedBy,
                        SuccessfulLogins = entity.SuccessfulLogins
                    };
                    //var obj = Mapper.Map<TUserDefaultPassword, TUserDefaultPasswordObject>(entity);
                    List.Add(obj);
                }
                return List.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool UpdateUserDefaultPassword(TCoreUsersPasswordObject obj)
        {
            var entity1 = _context.coreUsersPasswords.Find(obj.UserId);
            try
            {
                if (entity1 != null)
                {
                    UsersPassword entity = new UsersPassword
                    {
                        UserId = obj.UserId,
                        PwdEncrypt = obj.PwdEncrypt,
                        PwdExpiryDate = obj.PwdExpiryDate,
                        PwdChangedDate = obj.PwdChangedDate,
                        //LastModified = obj.LastModified,
                       // ModifiedBy = obj.ModifiedBy
                    };
                    _userdefaultpasswordRepository.Update(entity);
                   // _userdefaultpasswordRepository.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region User Old Passwords


        public UsersPasswordHistObject GetUserOldPassword(int? id)
        {

            try
            {
                if (id.HasValue)
                {
                    var entity = _useroldpasswordRepository.Find(id.Value);
                    // var obj = Mapper.Map<TCoreUsersPasswordHist, TCoreUsersPasswordHistObject>(entity);
                    UsersPasswordHistObject obj = new UsersPasswordHistObject
                    {
                        UserId = entity.CoreUserId,
                        PwdCount = entity.PwdCount,
                        PwdEncrypt = entity.PwdEncrypt,
                        CreatedBy = entity.CreatedBy,
                        DateCreated = DateTime.Now,
                        UpdatedBy = entity.UpdatedBy,
                        IsActive = true,
                        IsDeleted = false,
                    };

                    return obj;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UsersPasswordHistObject GetUserOldPasswordByProfile(long? userId)
        {

            try
            {
                if (userId.HasValue)
                {
                    var entity = _useroldpasswordRepository.Find(x => x.CoreUserId == userId);
                    //var obj = Mapper.Map<TCoreUsersPasswordHist, TCoreUsersPasswordHistObject>(entity);
                    UsersPasswordHistObject obj = new UsersPasswordHistObject
                    {
                        UserId = entity.CoreUserId,
                        PwdCount = entity.PwdCount,
                        PwdEncrypt = entity.PwdEncrypt,
                        CreatedBy = entity.CreatedBy,
                        DateCreated = DateTime.Now,
                        UpdatedBy = entity.UpdatedBy,
                        IsActive = true,
                        IsDeleted = false,
                    };

                    return obj;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UsersPasswordHistObject GetUserOldPasswords(long? id)
        {
            try
            {

                var entities = _useroldpasswordRepository.Find(x => x.Id == id);
               
               
                     UsersPasswordHistObject obj = new UsersPasswordHistObject
                    {
                        UserId = entities.CoreUserId,
                        PwdCount = entities.PwdCount,
                        PwdEncrypt = entities.PwdEncrypt,
                        CreatedBy = entities.CreatedBy,
                        DateCreated = DateTime.Now,
                        UpdatedBy = entities.UpdatedBy,
                        IsActive = true,
                        IsDeleted = false,
                    };
            
                 
                
                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool UpdateUserOldPassword(UsersPasswordHistObject obj)
        {
            var entity = _useroldpasswordRepository.Find(obj.UserId);
            try
            {
                if (entity != null)
                {
                    entity.DateUpdated = DateTime.Now;
                    //entity.HasExpired = true;

                    _useroldpasswordRepository.Update(entity);
                   // _useroldpasswordRepository.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<PasswordOptionsObject> GetPasswordOptions()
        {
            //try
            //{
            //    var entities = _passwordOptionRepository.All().ToList();
            //    IList<PasswordOptionsObject> List = new List<PasswordOptionsObject>();
            //    foreach (var entity in entities)
            //    {
            //        //var obj = Mapper.Map<PasswordOptions, PasswordOptionsObject>(entity);
            //        //obj.User = entity.Staff.FirstName + " " + entity.Staff.MiddleName + " " + entity.Staff.SurName;
            //        List.Add(obj);
            //    }
            //    return List.ToList();
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            return null;
        }

        public PasswordOptionsObject GetPasswordOption(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var entity = _passwordOptionRepository.Find(id.Value);
                    PasswordOptionsObject obj = new PasswordOptionsObject
                    {
                        RequiredLength = entity.RequiredLength,
                        RequireDigit = entity.RequireDigit,
                        RequiredUniqueChars = entity.RequiredUniqueChars,
                        RequireLowercase = entity.RequireLowercase,
                        RequireUppercase = entity.RequireUppercase,
                        RequireNonAlphanumeric = entity.RequireNonAlphanumeric
                        


                    };
                    //var obj = Mapper.Map<PasswordOptions, PasswordOptionsObject>(entity);
                    return obj;
                }
                throw new InvalidOperationException($"id - {id} doesn't exist in the system!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdatePasswordOption(PasswordOptionsObject obj)
        {
            var entity = _passwordOptionRepository.Find(obj.Id);
            try
            {
                if (entity != null)
                {
                   // entity.date = DateTime.Now;
                    _passwordOptionRepository.Update(entity);
                    //_passwordOptionRepository.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Dynamic Password Table Updaters
        //public void IncUserDefaultPasswordInvalidLogin(int? userId, int? Invalid, string UserName)
        //{
        //    try
        //    {
        //        //SQL CLient Operation
        //        var connection = _configura.GetConnectionString("OSMLiteDbConnection");
        //        SqlConnection con = new SqlConnection(connection);
        //        con.Open();

        //        //Date Converter
        //        DateTime mydateconverter = DateTime.Now;
        //        string sqlformattedDate = mydateconverter.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //        String queryString = "UPDATE t_core_users_password SET invalid_logins=@val,modified_by=@ModifiedBy,last_modified=@Date WHERE user_id=@uinstid;";
        //        SqlCommand cmd = new SqlCommand(queryString, con);
        //        cmd.Parameters.AddWithValue("@val", Invalid.Value);
        //        cmd.Parameters.AddWithValue("@ModifiedBy", UserName);
        //        cmd.Parameters.AddWithValue("@Date", sqlformattedDate);
        //        cmd.Parameters.AddWithValue("@uinstid", userId.Value);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public void IncUserDefaultPasswordSuccessfulLogin(TCoreUsersPasswordObject obj)
        {
            throw new NotImplementedException();
        }

        //public void IncUserDefaultPasswordCumulativeLogin(int? userId, int? Cumulative, string UserName)
        //{
        //    try
        //    {
        //        //SQL CLient Operation
        //        var connection = _configura.GetConnectionString("OSMLiteDbConnection");
        //        SqlConnection con = new SqlConnection(connection);
        //        con.Open();

        //        //Date Converter
        //        DateTime mydateconverter = DateTime.Now;
        //        string sqlformattedDate = mydateconverter.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //        String queryString = "UPDATE t_core_users_password SET cumulative_logins=@val,modified_by=@ModifiedBy,last_modified=@Date WHERE user_id=@uinstid;";
        //        SqlCommand cmd = new SqlCommand(queryString, con);
        //        cmd.Parameters.AddWithValue("@val", Cumulative.Value);
        //        cmd.Parameters.AddWithValue("@ModifiedBy", UserName);
        //        cmd.Parameters.AddWithValue("@Date", sqlformattedDate);
        //        cmd.Parameters.AddWithValue("@uinstid", userId);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public IEnumerable<TCoreUsersPasswordHistObject> GetUserOldPasswords(int? id)
        //{
        //    throw new NotImplementedException();
        //}

        //public TCoreUsersPasswordHistObject GetUserOldPasswordByProfile(int? userId)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion



    }
}