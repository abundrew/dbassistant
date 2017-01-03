using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace dbassistant.windows
{
    public class ReflectionInfo
    {
        public static Control GetControlByName(string name, Form currentform)
        {
            FieldInfo info = currentform.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            if (info != null)
                return (Control)info.GetValue(currentform);
            else
                return null;
        }

        public static Control GetControlByName(string name, UserControl currentusercontrol)
        {
            FieldInfo info = currentusercontrol.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            if (info != null)
                return (Control)info.GetValue(currentusercontrol);
            else
                return null;
        }
    }
}
