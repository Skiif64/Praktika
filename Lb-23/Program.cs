using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lb_23
{
    public class Program
    {
        static void Main(string[] args)
        {
            Graph graph;
            using (var sr = new StreamReader("graph.txt"))
            {
                var src = sr.ReadToEnd();
                graph = Graph.Deserialize(src);
                
            }
            Console.WriteLine("Граф:");
            Console.WriteLine(graph);
            var kuhnResult = KuhnSearch.FindMax(graph);
            Console.WriteLine($"Результат алгоритма Куна: {kuhnResult}");
            Console.ReadLine();
        }
    }

    public class KuhnSearch
    {
        private static List<bool> _used = new List<bool>();
        private static List<int> _mt = new List<int>();
        public static int FindMax(Graph graph)
        {
            var pairs = 0;
            foreach(var row in graph)
            {
                _mt.Add(-1);
                _used.Add(false);
                var result = Try_kuhn(row[0], graph);
                if (result)
                    pairs++;
            }
            return pairs;
        }
        private static bool Try_kuhn(int vertex, Graph graph)
        {   
            
            
            if (_used[vertex]) return false;
            _used[vertex] = true;
            for (int i = 0; i < graph.Length; ++i)
            {
                int to = graph[vertex][i];
                if (_mt[to] == -1 || Try_kuhn(_mt[to], graph))
                {
                    _mt[to] = vertex;
                    return true;
                }
            }
            return false;
        }

    }

    public class Graph : IEnumerable<int[]>
    {
        private readonly int[][] _graph;
        public int Length => _graph.Length;

        public Graph(int vertex)
        {
            _graph = new int[vertex][];
            for(int i=0;i<vertex;i++)
            {
                _graph[i] = new int[vertex];
            }
        }

        public int[] this[int index] => _graph[index];
        

        public void Insert(int fromIndex, int toIndex, int weight)
        {
            _graph[fromIndex][toIndex] = weight;
            _graph[toIndex][fromIndex] = weight;
        }

        public string Serialize()
        {
            var n = _graph.GetLength(0);
            string output = $"{n};{n}\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (_graph[i][j] > 0)
                    {
                        output += $"{i};{j};{_graph[i][j]}\n";
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
                    output += _graph[i][j] + " ";
                }
                output += '\n';
            }

            return output;
        }

        public IEnumerator<int[]> GetEnumerator()
        {
            foreach(var row in _graph)
            {
                yield return row;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var row in _graph)
            {
                yield return row;
            }
        }
    }
}
