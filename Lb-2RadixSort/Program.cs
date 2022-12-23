using PraktikaExtensions;
using System;

namespace Lb2RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n:");
            var n = int.Parse(Console.ReadLine());
            var array = new int[n].FillRandom(1, 100);
            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(", ", array));
            var sortedArray = RadixSort.Sort(array);
            Console.WriteLine("Отсортированный массив:");
            Console.WriteLine(string.Join(", ", sortedArray));
            Console.ReadLine();
        }

        class RadixSort
        {
            public static int[] Sort(int[] arr)
            {
                int i, j;
                int[] tmp = new int[arr.Length];
                for (int shift = 31; shift > -1; --shift)
                {
                    j = 0;
                    for (i = 0; i < arr.Length; ++i)
                    {
                        bool move = (arr[i] << shift) >= 0;
                        if (shift == 0 ? !move : move)
                            arr[i - j] = arr[i];
                        else
                            tmp[j++] = arr[i];
                    }
                    Array.Copy(tmp, 0, arr, arr.Length - j, j);
                }
                return arr;
            }
        }
    }
}
