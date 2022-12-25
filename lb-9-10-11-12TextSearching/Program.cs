using System;

namespace lb_9_10_11_12TextSearching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta delectus placeat itaque mollitia aspernatur, natus eligendi, deserunt consequatur voluptatibus nesciunt quisquam? Adipisci repellendus repellat provident porro cumque veritatis nostrum distinctio?";
            var key = "mollitia";
            var bfs = new BruteForceSearch();
            var kmps = new KnuthMorrisPrattSearch();
            var rks = new RabinKarpSearch();
            var bms = new BooyerMooreSearch();

            var bfsResult = bfs.Search(text, key);
            var kmpsResult = kmps.Search(text, key);
            var rksResult = rks.Search(text, key);
            var bmsResult = bms.Search(text, key);

            Console.ReadLine();

        }
    }
}
