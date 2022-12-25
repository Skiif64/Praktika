using System;
using System.Collections.Generic;

namespace lb_9_10_11_12TextSearching
{
    public class BooyerMooreSearch
    {
        public int[] Search(string text, string word)
        {
            List<int> result = new List<int>();
            int m = word.Length;
            int n = text.Length;

            int[] shifts = GetShifts(word);

            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;

                while (j >= 0 && word[j] == text[s + j])
                    --j;

                if (j < 0)
                {
                    result.Add(s);
                    s += (s + m < n) ? m - shifts[text[s + m]] : 1;
                }
                else
                {
                    s += Math.Max(1, j - shifts[text[s + j]]);
                }
            }

            return result.ToArray();
        }        
        private static int[] GetShifts(string word)
        {
            int m = word.Length;
            int i;
            int[] shifts = new int[2048];

            for (i = 0; i < 2048; i++)
                shifts[i] = -1;

            for (i = 0; i < m; i++)
                shifts[(int)word[i]] = i;
            return shifts;
        }
    }
}
