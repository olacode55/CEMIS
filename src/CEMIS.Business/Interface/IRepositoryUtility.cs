using CEMIS.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Data.Entities;
namespace CEMIS.Business.Interface
{
  public  interface IRepositoryUtility
    {
       List<SessionViewModel> GetsessionMemberListing();
       List<SessionViewModel> GetsessionbyMember();
       List<RevenueFixedAssetViewModel> GetRevenueFixedAsset();
       List<RevenueFixedAssetitem> GetRevenueFixedAssetItem();
        List<RevenueFixedAssetitem> GetAssetRevenuebyId(long Id);
    }
}
