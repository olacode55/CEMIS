using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIS.Web.CentralPortal.Utilities
{
    public class Notification
    {

        public string Message { get; set; }
        public NotificationsType Type { get; set; }
        public string Title { get; set; }
    }

    public enum NotificationsType
    {
        Danger,
        Success,
        Info,
        Warning
    }
}
