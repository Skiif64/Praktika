using System;

namespace lb_9_10_11_12TextSearching
{
    public class RabinKarpSearch
    {
        public string Search(string text, string word)
        {
            int n = text.Length;
            int m = word.Length;
            int hashText = Hash(text);
            int hashWord = Hash(word);

            string currentSegment = text.Substring(0, m);
            for (int i = 0; i < n - m; i++)
            {
                if (hashText == hashWord)
                    if (currentSegment == word)
                        return currentSegment;

                currentSegment = text.Substring(i + 1, m);
                hashText = Hash(currentSegment);
            }

            return string.Empty;

        }

        private int Hash(string text)
        {
            int hash = 0;
            for (int i = 0; i < text.Length; i++)
            {
                hash += (int)text[i];
            }
            hash = unchecked(hash * text.Length);
            return hash;
        }
    }
}
