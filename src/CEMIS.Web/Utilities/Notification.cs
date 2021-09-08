using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CEMIS.Web.Utilities
{
    public class Notification
    {

        public string Message { get; set; }
        public NotificationsType Type { get; set; }
        public string Title { get; set; }
    }

    public enum NotificationsType
    {
        danger,
        success,
        info,
        warning
    }

}

