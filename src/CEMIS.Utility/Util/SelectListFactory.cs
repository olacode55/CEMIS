using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.Util
{
   public class SelectListFactory: ISelectFactory
    {
        public List<SelectListItem> GetBooleanSelectList(bool isYesNo = false)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            if (isYesNo)
            {
                selectList.Add(new SelectListItem { Text = "No", Value = "false" });
                selectList.Add(new SelectListItem { Text = "Yes", Value = "true" });
            }
            else
            {
                selectList.Add(new SelectListItem { Text = "False", Value = "false" });
                selectList.Add(new SelectListItem { Text = "True", Value = "true" });
            }

            return selectList;
        }


    }
}
