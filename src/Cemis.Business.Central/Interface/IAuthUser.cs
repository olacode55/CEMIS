using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CEMIS.Business.Central.Interface
{
   public interface IAuthUser
    {
        string Name { get; }
        string UserId { get; }
       // string MerchantId { get; }
        //long BranchID { get;  }
        string IPAddress { get; }
      //  string Browser { get; }
        bool Authenticated { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
