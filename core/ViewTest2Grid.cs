using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XLSUploader.core
{
    public class ViewTest2Grid : BaseExelObject
    {
        public int Id { get; set; }
        public string Program { get; set; }
        public string Owner { get; set; }

        public ViewTest2Grid(int id, string program, string owner)
        {
            Id = id;
            Program = program;
            Owner = owner;
        }

        public override object GetProperties(string name)
        {
            Type thisType = typeof(ViewTest2Grid);

            PropertyInfo property = thisType.GetProperty(name);
            object value = property.GetValue(this);
            return value;
        }
    }
}
