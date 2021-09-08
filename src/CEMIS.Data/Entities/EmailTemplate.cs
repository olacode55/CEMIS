using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
   public  class EmailTemplate: BaseEntity
    {
        public int etemplate_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string subject { get; set; }
        public string body { get; set; }

    }
}
