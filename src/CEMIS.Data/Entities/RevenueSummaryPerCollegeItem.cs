using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueSummaryPerCollegeItem : ClientBaseEntity
    {
        public long RevEpenditureId { get; set; }

        public string PayitemName { get; set; }
       
    }
}
