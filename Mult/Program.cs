using System;

namespace Mult
{
    class Program
    {
        static void Main(string[] args)
        {
            const int testsCount = 4;
            int[,] multipliers = new int[testsCount, 2] { { 10, 2 }, { -93, -14 }, { 225, 673 }, { -7, 8 } };
            int testsFailed = 0;

            for(int i = 0; i < testsCount; i++)
            {
                testsFailed += MultTest(multipliers[i, 0], multipliers[i, 1]);
            }
            Console.WriteLine("============= Multiplication =============");
            Console.WriteLine("Tests run: {0}, failed: {1}", testsCount, testsFailed);
        }

        private static int Multiply(int x1, int x2)
        {
            bool positiveRes = true;
            if (x1 < 0)
            {
                positiveRes = false;
                x1 = Math.Abs(x1);
            }
            if (x2 < 0)
            {
                positiveRes = !positiveRes;
                x2 = Math.Abs(x2);
            }

            int res = 0;
            while (0 != x2)
            {
                if (0 != (x2 & 1))
                {
                    res += x1;
                }
                x1 = x1 << 1;
                x2 = x2 >> 1;
            }

            return (positiveRes ? res : -res);
        }

        private static int MultTest(int x1, int x2)
        {
            int expectedRes = x1 * x2;
            int res = Multiply(x1, x2);
            if (res != expectedRes)
            {
                Console.WriteLine("[ERROR]: {0} * {1}. Expected: {2}. Actual: {3}", x1, x2, expectedRes, res);
                return 1;
            }

            Console.WriteLine("[OK]: {0} * {1}. Expected: {2}. Actual: {3}", x1, x2, expectedRes, res);
            return 0;
        }
    }
}
