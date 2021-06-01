using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XLSUploader.core
{
    public class WorkListS : BaseExelObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string LicenseType { get; set; }
        public string Count { get; set; }
        public string ValiditiPeriod { get; set; }
        public string InstallPlace { get; set; }
        public string IsMicrosoft { get; set; }

        public WorkListS(string id, string name, string version, string licensetype, string count, string validitiperiod,
            string installplace, string isMiscrosoft)
        {
            Id = id;
            Name = name;
            Version = version;
            LicenseType = licensetype;
            Count = count;
            ValiditiPeriod = validitiperiod;
            InstallPlace = installplace;
            IsMicrosoft = isMiscrosoft;
        }
        public override object GetProperties(string name)
        {
            Type thisType = typeof(WorkListS);

            PropertyInfo property = thisType.GetProperty(name);
            object value = property.GetValue(this);
            return value;
        }
        public override Regex GetKeyComparer(object Object)
        {
            string KeyString = (string)Object;
            string[] arr_KeyString = KeyString.Split(' ');
            if (arr_KeyString[0] == "Windows" &&  int.TryParse(arr_KeyString[1], out _))
            {
                return new Regex(@"^Win\w");
            } 
            else if (arr_KeyString[0] == "Windows")
            {
                return new Regex(string.Format(@"^{0}\w", arr_KeyString[1]));
            } 
            else if (arr_KeyString[0] == "Win" && arr_KeyString[1] == "Pro" && int.TryParse(arr_KeyString[2], out _))
            {
                return new Regex(@"^Win\s");
            }
            else
            {
                return new Regex(string.Format(@"^{0}\s", Regex.Escape(arr_KeyString[0])));
            }
        }
        public override bool IsTryRegex(object Object, Regex otherRegex)
        {
            string parsing = (string)Object;

            if (otherRegex.IsMatch(parsing))
            {
                return true;
            }
            return false;
        }
    }
}
