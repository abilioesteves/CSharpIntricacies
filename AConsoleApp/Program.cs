using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsoleApp {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine(Checked.TestUnchecked());
            try { Checked.TestChecked(); } catch { Console.WriteLine("checked"); }

            Console.ReadLine();
        }
    }
}
