using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array1 = { 5, 4, 3, 2, 1 };
            int[] array2 = { 1, 2, 3, 4, 5 };
            int[] array3 = { 3, 1, 2, 5, 4 };
            int[] sortedArray = { 1, 2, 3, 4, 5 };

            int testsFailed = SortTest(array1, sortedArray);
            testsFailed += SortTest(array2, sortedArray);
            testsFailed += SortTest(array3, sortedArray);

            Console.WriteLine("============= Array Sorting =============");
            Console.WriteLine("Tests failed: {0}", testsFailed);
        }

        private static void Sort(int[] array)
        {
            SortLoop(array, 0, 0);
        }

        private static void SortLoop(int[] array, int i, int j)
        {
            if (i >= array.Length - 1)
            {
                return;
            }

            if (j >= array.Length - i - 1)
            {
                SortLoop(array, i + 1, 0);
            }
            else
            {
                SwapIfGreater(array, j, j + 1);
                SortLoop(array, i, j + 1);
            }
        }

        private static void SwapIfGreater(int[] array, int i, int j)
        {
            if (i >= array.Length || j >= array.Length)
            {
                return;
            }

            if (array[i] > array[j])
            {
                int tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;
            }
        }

        private static int SortTest(int[] array, int[] sortedArray)
        {
            if (array.Length != sortedArray.Length)
            {
                Console.WriteLine("[ERROR] Initial and expected arrays have different length! {0} and {1}", array.Length, sortedArray.Length);
                return 1;
            }

            Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != sortedArray[i])
                {
                    Console.WriteLine("[ERROR] Expected {0}. Actual: {1}", string.Join(",", sortedArray), string.Join(",", array));
                    return 1;
                }
            }
            Console.WriteLine("[OK] Expected {0}. Actual: {1}", string.Join(",", sortedArray), string.Join(",", array));
            return 0;
        }
    }
}
