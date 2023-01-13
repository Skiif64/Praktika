using System;
using System.IO;
using System.Linq;

namespace Lb_15Graph
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("graph.txt"))
            {
                var src = sr.ReadToEnd();
                var graph = Graph.Deserialize(src);
                Console.WriteLine(graph);
            }

            Console.ReadLine();
        }
    }

    public class Graph
    {
        private readonly int[,] _graph;
        public int Length => _graph.GetLength(0);

        public Graph(int vertex)
        {
            _graph = new int[vertex, vertex];
        }

        public void Insert(int fromIndex, int toIndex, int weight)
        {
            _graph[fromIndex, toIndex] = weight;
            _graph[toIndex, fromIndex] = weight;
        }

        public string Serialize()
        {
            var n = _graph.GetLength(0);
            string output = $"{n};{n}\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (_graph[i, j] > 0)
                    {
                        output += $"{i};{j};{_graph[i, j]}\n";
                    }
                }
            }
            return output;
        }

        public static Graph Deserialize(string source)
        {
            var rows = source.Split('\n');
            var dimensions = rows[0].Split(';');
            var vertex = int.Parse(dimensions[0]);

            var graph = new Graph(vertex);
            foreach (var row in rows.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(row))
                    break;
                var cols = row.Split(';');
                var fromIndex = int.Parse(cols[0]);
                var toIndex = int.Parse(cols[1]);
                var weight = int.Parse(cols[2]);
                graph.Insert(fromIndex, toIndex, weight);
            }
            return graph;
        }

        public override string ToString()
        {
            var output = "";
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    output += _graph[i, j] + " ";
                }
                output += '\n';
            }

            return output;
        }
    }
}
