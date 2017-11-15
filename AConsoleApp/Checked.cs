using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsoleApp {
    public class Checked {

        public static int TestUnchecked() {

            //int i1 = 2147483647 + 10; // Compile-time error
            //int i1 = int.MaxValue + 10; // Compile-time error
            int i = unchecked(int.MaxValue + 10); // No compile-time error

            int max = int.MaxValue;
            i = max + 10; // no compile-time error

            return i;
        }

        public static int TestChecked() {
            checked {
                int max = int.MaxValue;
                int i = max + 10;

                return i;
            }
        }

    }
}
