using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
    public interface ILevel
    {
        List<Level> GetAll();
        IEnumerable<SelectListItem> GetLevelList();
    }
}
