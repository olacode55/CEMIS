using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class GoodsAndServicesSettingsViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string AccountTitle { get; set; }
        public string Description { get; set; }
        public bool HasSubCategory { get; set; }
        public List<GoodsAndServicesSettingSubViewModel> SubItems;
    }


    public class GoodsAndServicesSettingSubViewModel
    {
        public long SettingsId { get; set; }
        public string Description { get; set; }
    }
}
