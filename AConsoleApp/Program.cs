using AClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsoleApp {
    class Program {
        static void Main(string[] args) {

            TestMisc();

            Console.ReadLine();
        }

        static void TestMisc() {
            Console.WriteLine($"{nameof(Checked.TestUnchecked)}: ");
            Console.WriteLine(Checked.TestUnchecked());

            Console.WriteLine($"{nameof(Checked.TestChecked)}: ");
            try { Checked.TestChecked(); } catch { Console.WriteLine("checked"); }

            Console.WriteLine($"{nameof(Arrays.Simple01)}: ");
            Arrays.Simple01();

            Console.WriteLine($"{nameof(Arrays.ArrayTest)}: ");
            Arrays.ArrayTest();

            Console.WriteLine($"{nameof(Arrays.MultiDimensionArrayForEach)}: ");
            Arrays.MultiDimensionArrayForEach();


            Console.WriteLine($"{nameof(Arrays.FillArray)}");
            string[] sArray = null;
            int[] iArray;
            Arrays.FillArray(out iArray);
            Arrays.FillArray(ref sArray);

            Console.WriteLine("sArray: {0}", string.Join(" ", sArray));
            Console.WriteLine("iArray: {0}", string.Join(" ", iArray));

            Console.WriteLine($"{nameof(Interops.ShowMessageBox)}: ");
            Interops.ShowMessageBox();
        }
    }
}
