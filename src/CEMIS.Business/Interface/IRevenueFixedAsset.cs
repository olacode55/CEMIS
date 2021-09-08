using System.Collections.Generic;
using CEMIS.Business.Model;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;

namespace CEMIS.Business.Interface
{
   public  interface IRevenueFixedAsset
    {
        int AddFixedAssetHead(RevenueFixedAssetHead model);
        RevenueFixedAssetHead GetRevenueFixedAssetById(long Id);
        int UpdateFixedItemHead(RevenueFixedAssetitem model,long Id);
        int AddFixedAssetitems(RevenueFixedAssetitem council);
        List<RevenueFixedAssetitem> GetAllFixedAssetitems(); 
         List<Revenueitemlog> GetAllFixedAssetitemslog();
        RevenueFixedAssetitem GetRevenuitembyId(long Id);
        RevenueFixedAssetitem GetRevenueFixedAssetitemById(long Id);
        List<RevenueFixedAssetHead> GetAllFixedAssetHead();
    }
}
