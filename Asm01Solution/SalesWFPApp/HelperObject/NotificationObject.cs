using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWFPApp.HelperObject
{
    public class NotificationObject
    {
        public static void DisplayMessage(string message = "")
        {
            MessageBox.Show(message);
        }
    }
}
