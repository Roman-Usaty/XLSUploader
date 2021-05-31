using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace XLSUploader.core
{
    public class ViewTestClasGrid : BaseExelObject
    {
        public int Id { get; set; }
        public string NameComp { get; set; }
        public string Program { get; set; }
        public ViewTestClasGrid(int id, string nameComp, string program)
        {
            Id = id;
            NameComp = nameComp;
            Program = program;
        }

        public override object GetProperties(string name)
        {
            Type thisType = typeof(ViewTestClasGrid);

            PropertyInfo property = thisType.GetProperty(name);
            object value = property.GetValue(this);
            return value;
        }
    }
}
