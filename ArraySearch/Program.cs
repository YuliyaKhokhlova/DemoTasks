using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int[] array1 = { 1, 2, 3, 1, 1 };
        int testsFailed = ArraySearchTest(array1, true, 1);

        int[] array2 = { 1, 2, 3, 3, 3, 3, 3, 1 };
        testsFailed += ArraySearchTest(array2, true, 3);

        int[] array3 = { 3, 4, 5, 6, 7, 8, 7, 6, 5 };
        testsFailed += ArraySearchTest(array3, false);

        int[] array4 = { 3, 4, 5, 6, 7, 8, 7, 6, 5, 4 };
        testsFailed += ArraySearchTest(array4, false);

        int[] array5 = { 1, 2, 2, 3 };
        testsFailed += ArraySearchTest(array5, false);

        Console.WriteLine("============= Array Search =============");
        Console.WriteLine("Tests failed: {0}", testsFailed);
    }

    private static bool ArraySearch(int[] array, ref int valueFound)
    {
        int arrayHalfLength = (array.Length + 1) / 2;
        Dictionary<int, int> elemFreqDict = new Dictionary<int, int>();

        // Count the number of entries for element of the first half
        for (int i = 0; i < array.Length; i++)
        {
            int curElem = array[i];
            if (elemFreqDict.ContainsKey(curElem))
            {
                elemFreqDict[curElem] += 1;
                continue;
            }

            if (i < arrayHalfLength)
            {
                elemFreqDict[curElem] = 1;
            }
        }

        // Find if there is an element which was met more than Length/2 times
        int minFreq = array.Length / 2 + 1;
        foreach (KeyValuePair<int, int> elemFreq in elemFreqDict)
        {
            if (elemFreq.Value >= minFreq)
            {
                valueFound = elemFreq.Key;
                return true;
            }
        }
        return false;
    }

    private static int ArraySearchTest(int[] array, bool expectedExist, int expectedValue = 0)
    {
        int value = 0;
        bool exist = ArraySearch(array, ref value);

        if (exist != expectedExist)
        {
            Console.WriteLine("[ERROR] Expected: value " + (expectedExist ? "" : "not ") + "found. Actual: value " + (exist ? "" : "not ") + "found");
            return 1;
        }

        if (value != expectedValue)
        {
            Console.WriteLine("[ERROR] Expected: value {0}. Actual: value {1}", expectedValue, value);
            return 1;
        }

        if (exist)
        {
            Console.WriteLine("[OK] Expected: value {0}. Actual: value {1}", expectedValue, value);
        }
        else
        {
            Console.WriteLine("[OK] Expected: value not found. Actual: value not found");
        }
        return 0;
    }
}