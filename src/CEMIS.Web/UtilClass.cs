using CEMIS.Business;
using CEMIS.Business.Interface;
using CEMIS.Business.Model;
using CEMIS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIS.Web.Util
{
    public class UtilClass
    {
        private static appContext _context;
        public static ISession _sessionRepo;
        public static IRepositoryUtility _repoclass;
        public UtilClass(appContext context, ISession SessionRepo, IRepositoryUtility repoutility)
        {
            _context = context;
            _sessionRepo = SessionRepo;
            _repoclass = repoutility;

        }

        public static List<SessionViewModel> GetSession()
        {
            var logquery = _repoclass.GetsessionbyMember().ToList();

            return logquery.ToList();


        }

        public static List<SessionViewModel> GetSection()
        {

            var _secModel = from s in _context.Sessions
                            where s.IsDeleted == false
                            orderby s.SessionName
                            select new SessionViewModel
                            {
                                SessionName = s.SessionName,
                                Id = s.Id
                            };
            return _secModel.ToList();
        }
    }

}

