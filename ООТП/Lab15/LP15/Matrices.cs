using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP15
{
    abstract class Matrices
    {
        public static int[,] MatrMul(int[,] m1,int[,]m2)
        {
            if (m1.GetUpperBound(1) + 1 != m2.GetUpperBound(0) + 1)
                throw new Exception("Error, product of 2 matrices is impossible, different number of rows and columns and matrices!");

            int[,] newMatrix = new int[m1.GetUpperBound(0) + 1, m2.GetUpperBound(1) + 1];

            for (var i = 0; i < m1.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < m2.GetUpperBound(1) + 1; j++)
                {
                    newMatrix[i, j] = 0;

                    for (var k = 0; k < m1.GetUpperBound(1) + 1; k++)
                    {
                        newMatrix[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return newMatrix;
        }

        public static void PrintMatr(int[,]m1)
        {
            for (var i = 0; i < m1.GetUpperBound(0)+1; i++)
            {
                for (var j = 0; j < m1.GetUpperBound(1)+1; j++)
                {
                    Console.Write(m1[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }


        public static void CreateArr(int i)
        {
            int[] arr = new int[i];
        }
        static void printDiv(int i)
        {
            Console.WriteLine(Div(i));
        }
        public static Int32 Div(Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
                checked { sum -= n; }
            return sum;
        }
        public static long forStd()
        {
            Stopwatch stopw = new Stopwatch();
            stopw.Start();

            for (int i = 0; i < 1000; ++i)
                CreateArr(i);
            stopw.Stop();
            Console.WriteLine($"Time standart cycle for: {stopw.ElapsedMilliseconds} ms");
            return stopw.ElapsedMilliseconds;
        }
        public static long foreachStd()
        {
            Stopwatch stopw = new Stopwatch();
            stopw.Start();
            int[] arr = new int[1000000];
            foreach (var item in arr)
            {
                CreateArr(item);
            }
            stopw.Stop();
            Console.WriteLine($"Time standart cycle foreach: {stopw.ElapsedMilliseconds} ms");
            return stopw.ElapsedMilliseconds;

        }

        public static long forPrll()
        {
            Stopwatch stopw = new Stopwatch();
            stopw.Start();

            Parallel.For(0, 100000, i => CreateArr(i));
            stopw.Stop();
            Console.WriteLine($"Time paraller cycle for: {stopw.ElapsedMilliseconds} ms");
            return stopw.ElapsedMilliseconds;
        }
        public static long foreachPrll()
        {
            Stopwatch stopw = new Stopwatch();
            stopw.Start();
            int[] arr = new int[1000000];
            Parallel.ForEach(arr,CreateArr);
            stopw.Stop();
            Console.WriteLine($"Time parallel cycle foreach: {stopw.ElapsedMilliseconds} ms");
            return stopw.ElapsedMilliseconds;
        }


        public static async void DivAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync");
            await Task.Run(() => printDiv(455)); // эта задача будет выполняться асинхронно
            Console.WriteLine("Конец метода FactorialAsync\n");
        }

    }
}
