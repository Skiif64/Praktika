using PraktikaExtensions;
using System;
using System.Linq;

namespace Lb_1Pyramid
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
            var sortedArray = PyramidSorter.Sort(array);
            Console.WriteLine("Отсортированный массив:");
            Console.WriteLine(string.Join(", ", sortedArray));
            Console.ReadLine();
        }

        class PyramidSorter
        {
            private static int Heapify(int[] arr, int i, int n)
            {
                int imax;
                int buffer;
                if ((2 * i + 2) < n)
                {
                    if (arr[2 * i + 1] > arr[2 * i + 2]) imax = 2 * i + 2;
                    else imax = 2 * i + 1;
                }
                else imax = 2 * i + 1;
                if (imax >= n) return i;
                if (arr[i] > arr[imax])
                {
                    buffer = arr[i];
                    arr[i] = arr[imax];
                    arr[imax] = buffer;
                    if (imax < n / 2) i = imax;
                }
                return i;
            }

            public static int[] Sort(int[] array)
            {
                var arr = array.ToArray();

                var n = arr.Length;

                for (int i = n / 2 - 1; i >= 0; --i)
                {
                    var iPrev = i;
                    i = Heapify(arr, i, n);
                    if (iPrev != i) ++i;
                }


                int buf;
                for (int k = n - 1; k > 0; --k)
                {
                    buf = arr[0];
                    arr[0] = arr[k];
                    arr[k] = buf;
                    int i = 0;
                    var iPrev = -1;
                    while (i != iPrev)
                    {
                        iPrev = i;
                        i = Heapify(arr, i, k);
                    }
                }

                return arr;
            }

        }
    }    
}