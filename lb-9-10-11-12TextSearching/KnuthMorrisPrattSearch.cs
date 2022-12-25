namespace lb_9_10_11_12TextSearching
{
    public class KnuthMorrisPrattSearch
    {
        public string Search(string text, string word)
        {
            int n = text.Length;
            int m = word.Length;
            var prefixes = GetPrefixes(word);
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                while (index > 0 && word[index] != text[i])
                {
                    index = prefixes[index - 1];
                }
                if (word[index] == text[i])
                    index++;

                if (index == m)
                    return text.Substring(i - index + 1, m);
            }

            return string.Empty;



        }

        private static int[] GetPrefixes(string word)
        {
            int n = word.Length;
            int[] result = new int[n];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                while (index >= 0 && word[index] != word[i])
                    index--;

                index++;
                result[i] = index;
            }

            return result;
        }
    }
}
