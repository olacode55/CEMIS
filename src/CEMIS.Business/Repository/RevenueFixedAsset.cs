using System.Collections.Generic;
using CEMIS.Business.Model;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Business.Interface;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CEMIS.Business.Repository
{
    public class RevenueFixedAsset : IRevenueFixedAsset
    {
        private IRepository<RevenueFixedAssetHead> _Repoestimate;
        private IRepository<RevenueFixedAssetitem> _Repofixeditem;
        private IRepository<Revenueitemlog> _Repofixeditemlog;
        private readonly IConfiguration _configration;
        public RevenueFixedAsset(IRepository<Revenueitemlog> Repofixeditemlog, IRepository<RevenueFixedAssetHead> Repoestimate, IConfiguration config, IRepository<RevenueFixedAssetitem> Repofixeditem)
        {
            _Repoestimate = Repoestimate;
            _configration = config;
            _Repofixeditem = Repofixeditem;
            _Repofixeditemlog = Repofixeditemlog;
        }

        public int AddFixedAssetHead(RevenueFixedAssetHead model)
        {
            try
            {
                RevenueFixedAssetHead _qmodels = new RevenueFixedAssetHead();

                _qmodels.CostCentre = model.CostCentre;
                _qmodels.MDA = model.MDA;
                _qmodels.ReportingPeriod = model.ReportingPeriod;
                _qmodels.ReportingYear = model.ReportingYear;
                _qmodels.IsActive = true;
                _Repoestimate.Create(_qmodels);
                return 1;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int AddFixedAssetitems(RevenueFixedAssetitem model)
        {
            try
            {
                RevenueFixedAssetitem _itm = new RevenueFixedAssetitem();
                _itm.Accounttitle = model.Accounttitle;
                _itm.AmountExpendedcurrentYear = model.AmountExpendedcurrentYear;
                _itm.Description = model.Description;
                _itm.ApproveBudget = model.ApproveBudget;
                _itm.Balance = model.Balance;
                _itm.Code = model.Code;
                _itm.CumulativeAmt = model.CumulativeAmt;
                _itm.RevEpenditureId = model.RevEpenditureId;
                _itm.TotalAmtexpendedtilldate = model.TotalAmtexpendedtilldate;
                _Repofixeditem.Create(_itm);
                return 1;


            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public  List<RevenueFixedAssetHead> GetAllFixedAssetHead()
        {
            try
            {
                List<RevenueFixedAssetHead> _revhead = _Repoestimate.All().ToList();
                if (_revhead != null)
                {
                    return _revhead.ToList();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return null;
        }

        public List<RevenueFixedAssetitem> GetAllFixedAssetitems()
        {
            try
            {
                List<RevenueFixedAssetitem> model = _Repofixeditem.All().ToList();
                return model.ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public RevenueFixedAssetHead GetRevenueFixedAssetById(long Id)
        {
            try
            {
                RevenueFixedAssetHead _fixeditm = _Repoestimate.Find(Id);
                if (_fixeditm != null)
                {
                    return _fixeditm;
                }
                return null;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public RevenueFixedAssetitem GetRevenuitembyId(long Id)
        {
            try
            {
                RevenueFixedAssetitem nnitem = _Repofixeditem.Find(Id);

                return nnitem;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int UpdateFixedItemHead(RevenueFixedAssetitem model,long Id)
        {
            try
            {
              
                RevenueFixedAssetitem nnitem = _Repofixeditem.Find(Id);
                RevenueFixedAssetitem asst = new RevenueFixedAssetitem();
                int deleteitm = _Repofixeditem.Delete(nnitem);
                RevenueFixedAssetitem _itm = new RevenueFixedAssetitem();
                _itm.Accounttitle = model.Accounttitle;
                _itm.AmountExpendedcurrentYear = model.AmountExpendedcurrentYear;
                _itm.ApproveBudget = model.ApproveBudget;
                _itm.Description = model.Description;
                _itm.Balance = model.Balance;
                _itm.Code = model.Code;
                _itm.CumulativeAmt = model.CumulativeAmt;
                _itm.RevEpenditureId = model.RevEpenditureId;
                _itm.TotalAmtexpendedtilldate = model.TotalAmtexpendedtilldate;
                _Repofixeditem.Create(_itm);
                return 1;
               
            }
            catch (System.Exception)
            {

                throw;
            }
        }
         public  RevenueFixedAssetitem GetRevenueFixedAssetitemById(long Id)
        {
            try
            {
                RevenueFixedAssetitem nnitem = _Repofixeditem.Find(Id);

                return nnitem;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<Revenueitemlog> GetAllFixedAssetitemslog()
        {
            try
            {
                List<Revenueitemlog> model = _Repofixeditemlog.All().ToList();
                return model.ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
