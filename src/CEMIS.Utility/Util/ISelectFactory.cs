using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.Util
{
  public  interface ISelectFactory
    {
        List<SelectListItem> GetBooleanSelectList(bool isYesNo = false);
    }
}
