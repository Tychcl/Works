using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBC
{
    static public class Check
    {
        static public bool FIO(string str)
        {
            return Regex.IsMatch(str, @"^\s*[а-яА-Я]+\s+[а-яА-Я]+\s+[а-яА-Я]+\s*$");
        }
        static public bool Phone(string str)
        {
            return Regex.IsMatch(str, @"\+7[0-9]{10}$") | Regex.IsMatch(str, @"8[0-9]{10}$");
        }
        static public bool Mail(string str)
        {
            return Regex.IsMatch(str, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
