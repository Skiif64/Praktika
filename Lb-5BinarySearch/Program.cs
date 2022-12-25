using Lb2RadixSort;
using PraktikaExtensions;
using System;

namespace Lb_5BInarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 250;
            var array = new int[n].FillRandom(0, 100);
            var sortedArray = RadixSort.Sort(array);
            var searchResultIndex = BinarySearch.Search(array, 5);
            Console.ReadLine();
        }

        public class BinarySearch
        {
            public static int Search(int[] array, int key)
            {
                int n = array.Length;
                int left = 0;
                int right = n - 1;
                int mid;
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (array[mid] == key) return mid;
                    if (array[mid] > key) right = mid - 1;
                    else left = mid + 1;
                }

                return -1;
            }
        }
    }
}