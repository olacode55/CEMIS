using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIS.Web.Utilities
{
    public class ManualJobHandler
    {
        private IConfiguration _configration;
        public ManualJobHandler(IConfiguration configration)
        {
            _configration = configration;
        }

        public ResponseData<List<BasicSalaryViewModel>> GetBasicSalary()
        {
            try
            {
                var apiKey = _configration.GetSection("APIKey").Value;
                string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("GetBasicSalary").Value.Replace("{API-Key}", apiKey);
                var postResponse = HTTPClientWrapper<ResponseData<List<BasicSalaryViewModel>>>.Get(url).Result;
                return postResponse;
            }catch(Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<List<BasicSalaryViewModel>>{
                    IsSuccessful = false,
                    Data = null,
                    Message = "Operation failed",
                    RespCode = "04"
                };
            }
        }


        public ResponseData<List<AllowanceViewModel>> GetAllowance()
        {
            try
            {
                var apiKey = _configration.GetSection("APIKey").Value;
                string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("GetAllowance").Value.Replace("{API-Key}", apiKey);
                var postResponse = HTTPClientWrapper<ResponseData<List<AllowanceViewModel>>>.Get(url).Result;
                return postResponse;
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<List<AllowanceViewModel>>
                {
                    IsSuccessful = false,
                    Data = null,
                    Message = "Operation failed",
                    RespCode = "04"
                };
            }
        }
    }
}
