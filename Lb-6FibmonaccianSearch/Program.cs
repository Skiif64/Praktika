using Lb2RadixSort;
using PraktikaExtensions;
using System;

namespace Lb_6FibmonaccianSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 250;
            var array = new int[n].FillRandom(0, 100);
            var sortedArray = RadixSort.Sort(array);
            var searchResultIndex = FibmonacchianSearch.Search(array, 5);
            Console.ReadLine();
        }

        class FibmonacchianSearch
        {
            public static int Search(int[] array, int key)
            {
                int n = array.Length;
                int fibMMm2 = 0;
                int fibMMm1 = 1;
                int fibM = fibMMm2 + fibMMm1;
                while (fibM < n)
                {
                    fibMMm2 = fibMMm1;
                    fibMMm1 = fibM;
                    fibM = fibMMm2 + fibMMm1;
                }

                int offset = -1;
                while (fibM > 1)
                {

                    int i = Math.Min(offset + fibMMm2, n - 1);

                    if (array[i] < key)
                    {
                        fibM = fibMMm1;
                        fibMMm1 = fibMMm2;
                        fibMMm2 = fibM - fibMMm1;
                        offset = i;
                    }

                    else if (array[i] > key)
                    {
                        fibM = fibMMm2;
                        fibMMm1 = fibMMm1 - fibMMm2;
                        fibMMm2 = fibM - fibMMm1;
                    }

                    else return i;
                }

                if (fibMMm1 != 0 && array[offset + 1] == key)
                    return offset + 1;

                return -1;
            }
        }
    }
}