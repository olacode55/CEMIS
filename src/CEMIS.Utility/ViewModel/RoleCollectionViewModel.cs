using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class RoleCollectionViewModel
    {
        public long roleid { get; set; }
        public string rolename { get; set; }
        public string roledesc { get; set; }
        public IList<UsersObject> assignedusers { get; set; }
        public IList<UsersObject> unassignedusers { get; set; }
    }
}
