namespace lb_9_10_11_12TextSearching
{
    public class BruteForceSearch
    {
        public bool Search(string text, string word)
        {
            int n = text.Length;
            int m = word.Length;

            int res = -1;
            for (int i = 0; i < n - m + 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (text[i + j] != word[j])
                        break;
                    else if (j == m - 1)
                    {
                        res = i;
                        break;
                    }

                }
            }

            return res != -1;
        }
    }
}
