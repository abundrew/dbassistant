using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dbassistant.windows
{
    public class Text
    {
        public static string[] Wrap(string text, int width)
        {
            List<string> ss = new List<string>();

            foreach (string line in text.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            {
                string _line = line;

                while (_line.Length > width)
                {
                    int ix = _line.Substring(0, width).LastIndexOf(" ", width);

                    if (ix == -1) ix = width;

                    ss.Add(_line.Substring(0, ix));
                    _line = _line.Substring(ix).TrimStart(); ;
                }

                ss.Add(_line);
            }
            return ss.ToArray();
        }

        public static string Omit(string text, int length)
        {
            if (!string.IsNullOrEmpty(text) && text.Length > length)
                return string.Format("{0}...", text.Substring(0, length));
            else
                return text;
        }

        public static bool IsDigit(string s)
        {
            foreach (char c in s)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }
    }
}
