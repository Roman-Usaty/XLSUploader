﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLSUploader.core
{
    public class ViewTestClasGrid
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

    }
}
