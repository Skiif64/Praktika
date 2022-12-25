using Lb2RadixSort;
using PraktikaExtensions;
using System;

namespace Lb_7InterpolateSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 250;
            var array = new int[n].FillRandom(0, 100);
            var sortedArray = RadixSort.Sort(array);
            var searchResultIndex = InterpolateSearch.Search(array, 5);
            Console.ReadLine();
        }

        class InterpolateSearch
        {
            public static int Search(int[] array, int key)
            {
                int n = array.Length;
                int lo = 0;
                int hi = n - 1;
                int mid = -1;
                int index = -1;
                while (lo <= hi)
                {
                    mid = lo + (int)((((double)(hi - lo) / (array[hi] - array[lo])) *
                    (key - array[lo])));
                    if (array[mid] == key) { index = mid; break; }
                    else
                    {
                        if (array[mid] < key)
                        {

                            lo = mid + 1;
                        }
                        else
                        {
                            hi = mid - 1;
                        }
                    }
                }
                return index;
            }
        }
    }
}