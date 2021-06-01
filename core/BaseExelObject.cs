using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XLSUploader.core
{
    public abstract class BaseExelObject
    {
        public abstract object GetProperties(string name);

        public abstract Regex GetKeyComparer(object Object);

        public abstract bool IsTryRegex(object Object, Regex otherRegex);
    }
}