using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AConsoleApp {
    public class Interops {

        [DllImport("User32.dll", CharSet=CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        public static int ShowMessageBox() {
            string str;
            Console.WriteLine("Enter your message: ");
            str = Console.ReadLine();
            return MessageBox((IntPtr)0, str, "MyMessageBox", 0);
        }

    }
}
