using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
namespace CEMIS.Web.Utilities
{
    public class Webutilities
    {
        public static string GenerateLabel(string name)
        {
            var labelString = $"<label for=\"{name}\">{name}</label>";
            return labelString;
        }

        public static string GenerateDropdown(string name, string[] options)
        {
            name = name.Replace(" ", "");
            StringBuilder dropdownString = new StringBuilder();
            dropdownString.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", name);
            dropdownString.AppendFormat("<option>Select...</option>");
            for (int i = 0; i < options.Count(); i++)
            {
                dropdownString.AppendFormat("<option value={0}>{0}</option>", options[i]);
            }
            dropdownString.AppendFormat("</select>");
            return dropdownString.ToString();
        }

        public static string GenerateTextBox(string name, string type, string options, string value)
        {
            var textboxString = "";
            name = name.Replace(" ", "");
            switch (type)
            {
                case "String":
                    textboxString = $"<input type=\"text\" class=\"form-control\" value =\"{value}\" id=\"{name}\" name=\"{name}\">";
                    break;
                case "Number":
                    textboxString = $"<input type=\"number\" class=\"form-control\" value =\"{value}\" id=\"{name}\" name=\"{name}\">";
                    break;
                case "Date":
                    textboxString = $"<input type=\"date\" class=\"form-control datepicker\" value =\"{value}\" id=\"{name}\" name=\"{name}\">";
                    break;
                case "Checkbox":
                    var check = value == "checked" ? "checked" : string.Empty;
                    textboxString = $"<input type=\"checkbox\" class=\"form-control\" {check} id=\"{name}\" name=\"{name}\">";
                    break;

                case "Dropdown":
                    name = name.Replace(" ", "");
                    StringBuilder dropdownString = new StringBuilder();
                    dropdownString.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", name);
                    dropdownString.AppendFormat("<option>Select...</option>");
                    var opt = options.Split(',');
                    for (int i = 0; i < opt.Count(); i++)
                    {
                        dropdownString.AppendFormat("<option value={0}>{0}</option>", opt[i]);
                    }
                    dropdownString.AppendFormat("</select>");
                    textboxString = dropdownString.ToString();
                    break;
            }
            return textboxString;
        }

        //public string GetPortalURL()
        //{
        //    try
        //    {
        //        string hostURL = System.Web.HttpContext.Current.Request.Url.Scheme;
        //        string siteURL = System.Web.HttpContext.Current.Request.Url.Authority;
        //        string appPath = System.Web.HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
        //        string portalUrl = string.Format("{0}://{1}{2}", hostURL, siteURL, appPath);

        //        return portalUrl;
        //    }

        //    catch (Exception)
        //    {
        //        return "http://";
        //    }

            public static string GenerateFacilityPageTextBox(string name, string type, string options, string value, bool enableFunctionCaller, string function)
        {
            var textboxString = "";
            name = name.Replace(" ", "");

            var onchange = enableFunctionCaller ? "onchange='" + function + "'" : string.Empty;
            switch (type)
            {
                case "String":
                    textboxString = $"<input type=\"text\" class=\"form-control\"  value =\"{value}\" id=\"{name}\" name=\"{name}\" {onchange}>";
                    break;
                case "Number":
                    textboxString = $"<input type=\"number\" class=\"form-control\"  value =\"{value}\" id=\"{name}\" name=\"{name}\" {onchange}>";
                    break;
                case "Date":
                    textboxString = $"<input type=\"date\" class=\"form-control  datepicker\" value =\"{value}\" id=\"{name}\" name=\"{name}\">";
                    break;
                case "Checkbox":
                    var check = value == "checked" ? "checked" : string.Empty;
                    textboxString = $"<input type=\"checkbox\" class=\"form-control\" {check} id=\"{name}\" name=\"{name}\">";
                    break;

                case "Dropdown":
                    name = name.Replace(" ", "");
                    StringBuilder dropdownString = new StringBuilder();
                    dropdownString.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", name);
                    dropdownString.AppendFormat("<option>Select...</option>");
                    var opt = options.Split(',');
                    for (int i = 0; i < opt.Count(); i++)
                    {
                        dropdownString.AppendFormat("<option value={0}>{0}</option>", opt[i]);
                    }
                    dropdownString.AppendFormat("</select>");
                    textboxString = dropdownString.ToString();
                    break;
            }
            return textboxString;
        }


        public static string GenerateClassRoom(int count)
        {
            string yearOfConstruction = $"<input type=\"number\" class=\"form-control\" Required placeholder='Year Of Construction' id=\"{"YearOfConstruction"}\" name=\"{"YearOfConstruction"}\">";

            string lengthInMeters = $"<input type=\"number\" class=\"form-control\" Required placeholder=Length id=\"{"Length"}\" name=\"{"Length"}\">";

            string widthInMeters = $"<input type=\"number\" class=\"form-control\" Required placeholder=Width id=\"{"Width"}\" name=\"{"Width"}\">";
            StringBuilder presentCondition = new StringBuilder();
            presentCondition.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", "PresentCondition");
            var classcoditionEnum = GetValues<ClassRoomCondition>();
            foreach (var enumKey in classcoditionEnum)
            {
                //var d = (ClassRoomCondition)Enum.Parse(typeof(ClassRoomCondition), enumKey.ToString());
                // int enumValue = Enum.Parse(typeof((ClassRoomCondition), enumKey);
                presentCondition.AppendFormat("<option value={0}>{1}</option>", (int)enumKey, enumKey);
            }
            presentCondition.AppendFormat("</select>");

            StringBuilder floorMaterial = new StringBuilder();
            floorMaterial.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", "FloorMaterial");
            var floorMaterialEnum = GetValues<FloorMaterial>();
            foreach (var item in floorMaterialEnum)
            {

                floorMaterial.AppendFormat("<option value={0}>{1}</option>", (int)item, item);
            }
            floorMaterial.AppendFormat("</select>");


            StringBuilder wallMaterial = new StringBuilder();
            wallMaterial.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", "WallMaterial");
            var wallMaterialEnum = GetValues<WallMaterial>();
            foreach (var item in wallMaterialEnum)
            {
                wallMaterial.AppendFormat("<option value={0}>{1}</option>", (int)item, item.ToString());
            }
            wallMaterial.AppendFormat("</select>");


            StringBuilder roofMaterial = new StringBuilder();
            roofMaterial.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", "RoofMaterial");
            var roomMaterialEnum = GetValues<RoofMaterial>();
            foreach (var item in roomMaterialEnum)
            {
                roofMaterial.AppendFormat("<option value={0}>{1}</option>", (int)item, item.ToString());
            }
            roofMaterial.AppendFormat("</select>");


            StringBuilder seating = new StringBuilder();
            seating.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", "Seating");
            var sitAvailabilityEnum = GetValues<SeatAvailability>();
            foreach (var item in sitAvailabilityEnum)
            {
                seating.AppendFormat("<option value={0}>{1}</option>", (int)item, item.ToString());
            }
            seating.AppendFormat("</select>");

            StringBuilder disabledAccess = new StringBuilder();
            disabledAccess.AppendFormat("<select class=\"custom-select\" id=\"{0}\" name=\"{0}\">", "DisabledAccess");
            var disabilityAccessAvailability = GetValues<DisabilityAccessAvailability>();
            foreach (var item in disabilityAccessAvailability)
            {
                disabledAccess.AppendFormat("<option value={0}>{1}</option>", (int)item, item.ToString());
            }
            disabledAccess.AppendFormat("</select>");



            StringBuilder html = new StringBuilder();
            html.AppendFormat("<table>");


            html.AppendFormat("<tr>");
            html.Append("<th>");
            html.Append("Year Of Construction");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Present Condition");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Length");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Width");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Wall Material");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Roof Material");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Sit Availability");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Disability Access");
            html.Append("</th>");

            html.AppendFormat("</tr>");

            for (int x = 0; x < count; x++)
            {
                html.AppendFormat("<tr>");
                html.Append("<td>");
                html.Append(yearOfConstruction);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(presentCondition);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(lengthInMeters);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(widthInMeters);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(wallMaterial);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(roofMaterial);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(seating);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(disabledAccess);
                html.Append("</td>");

                html.AppendFormat("</tr>");
            }


            html.AppendFormat("</table>");
            return html.ToString();
        }

        public static string GenerateGoodsAndServicesAddNew(List<GoodsAndServicesSettings> settings)
        {
            var subCatCount = 0;
            var html = new StringBuilder();
            var hiddenDiv = new StringBuilder();

            html.AppendFormat("<div id='hiddendiv'>");





            html.AppendFormat("<table class='table table-bordered table-striped table-hover' style='border: 1px solid #ddd !important;'>");

            html.AppendFormat("<tr>");
            html.Append("<th>");
            html.Append("Code");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Account Title");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Description");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Approve Budget");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Amount Expended");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Cummulative Amount Expended");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Total Amount Expended To Date");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Balance");
            html.Append("</th>");

            html.AppendFormat("</tr>");

            foreach (var item in settings)
            {

                if (item.HasSubCategory == true)
                {
                    html.AppendFormat("<tr>");
                    html.Append("<td>");
                    html.Append(item.Code);
                    html.Append("</td>");

                    html.Append("<td>");
                    html.Append(item.AccountTitle);
                    html.Append("</td>");

                    html.Append("<td>");
                    html.Append(item.Description);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(approvedBuget);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(amountExpended);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(cummulativeAmt);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(totalAmt);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(balance);
                    html.Append("</td>");
                    html.AppendFormat("</tr>");


                    if (item.Items != null)
                    {

                        hiddenDiv.Append($"<input type =\"hidden\" id=\"{""}\" name=\"{"ItemID" + subCatCount.ToString()}\"  value=\"{item.Id }\" >");

                        foreach (var sub in item.Items)
                        {
                            var approvedBuget = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.approvedBuget + sub.Id}\"  onchange=\"calculateBalance(this.id)\" name=\"{ApplicationConstant.approvedBuget + sub.Id}\">";
                            var amountExpended = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.amountExpended + sub.Id}\" onchange=\"calculateBalance(this.id)\" name=\"{ApplicationConstant.amountExpended + sub.Id}\">";
                            var cummulativeAmt = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.cummulativeAmt + sub.Id}\" onchange=\"calculateBalance(this.id)\" name=\"{ApplicationConstant.cummulativeAmt + sub.Id}\">";
                            var totalAmt = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.totalAmt + sub.Id}\" name=\"{ApplicationConstant.totalAmt + sub.Id}\">";
                            var balance = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.balance + sub.Id}\" name=\"{ApplicationConstant.balance + sub.Id}\">";

                            html.AppendFormat("<tr>");
                            html.Append("<td>");
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(sub.Description);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(approvedBuget);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(amountExpended);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(cummulativeAmt);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(totalAmt);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(balance);
                            html.Append("</td>");
                            html.AppendFormat("</tr>");
                        }

                        subCatCount++;
                    }

                }
                else
                {
                    html.AppendFormat("<tr>");
                    html.Append("<td><strong>");
                    html.Append(item.Code);
                    html.Append("</strong></td>");

                    html.Append("<td><strong>");
                    html.Append(item.AccountTitle);
                    html.Append("</strong></td>");

                    html.Append("<td colspan = 6><strong>");
                    html.Append(item.Description);
                    html.Append("</strong></td>");
                    html.AppendFormat("</tr>");
                }
            }
            html.AppendFormat("</table>");
            hiddenDiv.Append($"<input type =\"hidden\" id=\"{""}\" name=\"{"subCatCount"}\" value=\"{subCatCount}\" >");
            html.AppendFormat("</div>");

            return html.ToString() + hiddenDiv.ToString();
        }

        public static string GenerateGoodsAndServicesEdit(List<GoodsAndServicesItemsViewModel> goodsAndServicesItemsVM, List<GoodsAndServicesSettingsViewModel> goodsAndServicesSettingsVM)
        {
            var subCatCount = 0;
            var html = new StringBuilder();
            var hiddenDiv = new StringBuilder();

            html.AppendFormat("<div id='hiddendiv'>");

            var headerHiddenTextBox = string.Empty;





            html.AppendFormat("<table class='table table-bordered table-striped table-hover' style='border: 1px solid #ddd !important;'>");

            html.AppendFormat("<tr>");
            html.Append("<th>");
            html.Append("Code");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Account Title");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Description");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Approve Budget");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Amount Expended");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Cummulative Amount Expended");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Total Amount Expended To Date");
            html.Append("</th>");

            html.Append("<th>");
            html.Append("Balance");
            html.Append("</th>");

            html.AppendFormat("</tr>");

            foreach (var item in goodsAndServicesSettingsVM)
            {



                if (item.HasSubCategory == true)
                {
                    html.AppendFormat("<tr>");
                    html.Append("<td>");
                    html.Append(item.Code);
                    html.Append("</td>");

                    html.Append("<td>");
                    html.Append(item.AccountTitle);
                    html.Append("</td>");

                    html.Append("<td>");
                    html.Append(item.Description);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(approvedBuget);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(amountExpended);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(cummulativeAmt);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(totalAmt);
                    html.Append("</td>");

                    html.Append("<td>");
                    //html.Append(balance);
                    html.Append("</td>");
                    html.AppendFormat("</tr>");


                    if (goodsAndServicesItemsVM != null)
                    {

                        var goodsAndServicesList = goodsAndServicesItemsVM.Where(x => x.SettingsId == item.Id).ToList();

                        hiddenDiv.Append($"<input type =\"hidden\" id=\"{""}\" name=\"{"ItemID" + subCatCount.ToString()}\"  value=\"{item.Id }\" >");

                        foreach (var sub in goodsAndServicesList)
                        {

                            if (headerHiddenTextBox == string.Empty)
                            {
                                headerHiddenTextBox = $"<input type =\"hidden\" id=\"{""}\" name=\"{"GoodsAndServicesHeaderID"}\"  value=\"{sub.RevenueGoodandServiceHeadID}\" >";
                                hiddenDiv.Append(headerHiddenTextBox);
                            }
                            var approvedBuget = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.approvedBuget + sub.Id}\" onchange=\"calculateBalance(this.id)\" value=\"{sub.ApproveBudget}\" name=\"{ApplicationConstant.approvedBuget + sub.Id}\">";
                            var amountExpended = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.amountExpended + sub.Id}\" onchange=\"calculateBalance(this.id)\"  value=\"{sub.AmountExpendedcurrentYear}\" name=\"{ApplicationConstant.amountExpended + sub.Id}\">";
                            var cummulativeAmt = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.cummulativeAmt + sub.Id}\" onchange=\"calculateBalance(this.id)\" value=\"{sub.CumulativeAmt}\" name=\"{ApplicationConstant.cummulativeAmt + sub.Id}\">";
                            var totalAmt = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.totalAmt + sub.Id}\" value=\"{sub.TotalAmtexpendedtilldate}\" name=\"{ApplicationConstant.totalAmt + sub.Id}\">";
                            var balance = $"<input type=\"number\" class=\"form-control\" id=\"{ApplicationConstant.balance + sub.Id}\" value=\"{sub.Balance}\" name=\"{ApplicationConstant.balance + sub.Id}\">";

                            html.AppendFormat("<tr>");
                            html.Append("<td>");
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(sub.Description);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(approvedBuget);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(amountExpended);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(cummulativeAmt);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(totalAmt);
                            html.Append("</td>");

                            html.Append("<td>");
                            html.Append(balance);
                            html.Append("</td>");
                            html.AppendFormat("</tr>");
                        }

                        subCatCount++;
                    }

                }
                else
                {
                    html.AppendFormat("<tr>");
                    html.Append("<td><strong>");
                    html.Append(item.Code);
                    html.Append("</strong></td>");

                    html.Append("<td><strong>");
                    html.Append(item.AccountTitle);
                    html.Append("</strong></td>");

                    html.Append("<td colspan = 6><strong>");
                    html.Append(item.Description);
                    html.Append("</strong></td>");
                    html.AppendFormat("</tr>");
                }
            }
            html.AppendFormat("</table>");
            hiddenDiv.Append($"<input type =\"hidden\" id=\"{""}\" name=\"{"subCatCount"}\" value=\"{subCatCount}\" >");
            html.AppendFormat("</div>");

            return html.ToString() + hiddenDiv.ToString();
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }


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

        public static string GetInitialCharacter(string input)
        {
            string output = "";

            input.Split(' ').ToList().ForEach(i => output += i[0].ToString().ToUpper());

            return output;

        }


        public static string RandomString(int length = 0)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }


        public static string GenerateRegPin(string CollegeCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(CollegeCode.ToUpper());
            builder.Append(RandomNumber(100000, 999999));
            builder.Append(RandomString(6));
            return builder.ToString();
        }



    }
}
