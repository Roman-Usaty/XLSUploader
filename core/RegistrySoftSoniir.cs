using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XLSUploader.core
{
    public class RegistrySoftSoniir : BaseExelObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Function { get; set; }
        public string StartDate { get; set; }
        public string Code { get; set; }
        public string IsRussia { get; set; }

        public RegistrySoftSoniir(string id, string name, string owner, string function, string startdate, 
            string code, string isRussia)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Function = function;
            StartDate = startdate;
            Code = code;
            IsRussia = isRussia;
        }
        public override object GetProperties(string name)
        {
            Type thisType = typeof(RegistrySoftSoniir);

            PropertyInfo property = thisType.GetProperty(name);
            object value = property.GetValue(this);
            return value;
        }
        public override Regex GetKeyComparer(object Object)
        {
            string KeyString = (string)Object;
            string[] arr_KeyString = KeyString.Split(' ');

            if(arr_KeyString[0] == "Windows" || arr_KeyString[0] == "Win")
            {
                if (arr_KeyString[1] == "10")
                {
                    return new Regex(@"(\AWin Pro 10)|(^Windows Pro 10)");
                }
                else if (arr_KeyString[1] == "XP,")
                {
                    return new Regex(@"(Windows|\AWindows)\s(XP|7|Vista)\s\w");
                }
                else if (arr_KeyString[1] == "Server")
                {
                    return new Regex(@"\AWindows\sServer");
                }
            }
            else if (arr_KeyString[0] == "Exchange")
            {
                return new Regex(string.Format(@"^{0}\s", arr_KeyString[0]));
            }
            else if (arr_KeyString.Length < 2)
            {
                return new Regex(string.Format(@"^{0}", Regex.Escape(arr_KeyString[0])));
            }
            else
            {
                return new Regex(string.Format(@"^{0}\s{1}", Regex.Escape(arr_KeyString[0]), Regex.Escape(arr_KeyString[1])));
            }
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
