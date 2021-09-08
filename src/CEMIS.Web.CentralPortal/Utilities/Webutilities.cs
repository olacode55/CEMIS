
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEMIS.Utility.ViewModel;
using CEMIS.Utility;

namespace CEMIS.Web.Utilities
{
    public class Webutilities
    {
        public static string DisplayAlert(WebAlert webalert = null)
        {
            if (webalert != null)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("$(document).ready(function () {");

                //sb.Append("function Alert(){");

                sb.Append(@"toastr.options = {
                'debug': false,
                'newestOnTop': false,
                'positionClass': 'toast-top-center',
                'closeButton': true,
                'toastClass': 'animated fadeInDown'};");

                if (webalert.AlertType == AlertEnum.Info)
                {
                    sb.Append("toastr.info('" + webalert.Message + "');");
                }
                else if (webalert.AlertType == AlertEnum.Success)
                {
                    sb.Append("toastr.success('" + webalert.Message + "');");
                }
                else if (webalert.AlertType == AlertEnum.Error)
                {
                    sb.Append("toastr.error('" + webalert.Message + "');");
                }
                else if (webalert.AlertType == AlertEnum.Warning)
                {
                    sb.Append("toastr.warning('" + webalert.Message + "');");
                }

                sb.Append("});");

                return sb.ToString();

            }
            else
            {
                return string.Empty;
            }

        }

    }
}
