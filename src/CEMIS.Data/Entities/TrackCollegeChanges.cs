using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class TrackCollegeChanges
    {
        public int Id { get; set; }
        public int ModuleID { get; set; }
        public bool HasChanged { get; set; }
    }
}
