using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLSUploader.core
{
    public class ViewTest2Grid
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
    }
}
