using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Utils
{
    internal class TextEditor
    {
        public static string TrimAndLower(string inputString)
        {
            return inputString.Trim().ToLower();
        }

        public static bool ContainsLower(string main, string contains)
        {
            string firstString = main.Trim().ToLower();
            string containgString = contains.Trim().ToLower();
            if (firstString.Contains(containgString))
                return true;
            return false;
        }
    }
}
