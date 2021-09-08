using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class AllowanceViewModel
    {
        public long Id { get; set; }
        public string name { get; set; }
        public long ParentId { get; set; }
        public bool IsBasicSalry { get; set; }
    }

    }
