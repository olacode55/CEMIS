using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
    public interface IGoodsAndServices
    {
        List<GoodsAndServicesSettings> CreateGoodsAndServices();
        List<RevenueGoodandServiceHead> GetGoodsAndServices();
        GoodsAndServicesHeaderViewModel GetGoodAndServiceDetails(long Id);
        void AddGoodAndServices(GoodsAndServicesHeaderViewModel item);
        GoodsAndServicesHeaderViewModel GetGoodsAndServicesById(long Id);
    }
}
