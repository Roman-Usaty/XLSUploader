using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLSUploader.core
{
    public class ResultObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string LicenseType { get; set; }
        public string Count { get; set; }
        public string ValiditiPeriod { get; set; }
        public string InstallPlace { get; set; }
        public string IsMicrosoft { get; set; }
        public string RegistryName { get; set; }
        public string Owner { get; set; }
        public string Function { get; set; }
        public string StartDate { get; set; }
        public string Code { get; set; }
        public string IsRussia { get; set; }


        public List<string> GetList()
        {
            return new List<string>() { Id, Name, Version, LicenseType, Count,
                ValiditiPeriod, InstallPlace,
                IsMicrosoft, RegistryName, Owner,
                Function, StartDate, Code, IsRussia};
        }
    }
}
