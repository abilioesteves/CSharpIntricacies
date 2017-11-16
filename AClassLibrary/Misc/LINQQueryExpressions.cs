using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AClassLibrary {
    public class Arrays {

        public static void Simple01() {
            // data
            int[] scores = new int[] { 97, 92, 81, 60 };

            // query
            IEnumerable<int> scoreQuery = from score in scores
                                          where score > 80
                                          select score;

            // query execution
            foreach (int i in scoreQuery) {
                Console.WriteLine($"{i} ");
            }
        }

        public static void ArrayTest() {
            // declares the array of two elements
            int[][] arr = new int[2][];

            // initialize the elements
            arr[0] = new int[5] { 1, 3, 5, 7, 9};
            arr[1] = new int[4] { 2, 4, 6, 8 };

            // Display the array elements
            for (int i = 0; i < arr.Length; i++) {
                Console.WriteLine();
                Console.Write($"Element({i}): ");

                for (int j = 0; j < arr[i].Length; j++) {
                    Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }
            }
            Console.WriteLine();
        }

        public static void MultiDimensionArrayForEach() {
            int[,,] arr = { { { 1, 2, 3 }, { 3, 2, 1 } }, { { 4, 5, 6 }, { 6, 5, 4 } }, { { 7, 8, 9 }, { 9, 8, 7 } } };

            Console.WriteLine($"{nameof(MultiDimensionArrayForEach)}");
            foreach (var e in arr) {
                Console.Write($"{e} ");
            }
            Console.WriteLine();
        }

        public static void FillArray(ref string[] array) {
            if (array == null) {
                array = new string[] { "1", "2", "3", "4", "5" };
            }

            array[0] = "0";
        }

        public static void FillArray(out int[] array) {
            array = new int[] { 1, 2, 3, 4, 5 };
        }
    }
}
