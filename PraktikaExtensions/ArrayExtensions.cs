using System;

namespace PraktikaExtensions
{
    public static class ArrayExtensions
    {
        public static int[] FillRandom(this int[] array, int from, int to)
        {
            var random = new Random();
            var n = array.Length;
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(from, to);
            }
            return array;
        }
    }
}
