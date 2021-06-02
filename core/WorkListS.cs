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
            return null;
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
