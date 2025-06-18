using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBFS
{
    internal class GraphBreathFirstSearch
    {
        private Dictionary<string, List<string>> Graph;
        public GraphBreathFirstSearch()
        {
            Graph = new Dictionary<string, List<string>>();
        }

        public void Edges(List<(string, string)> list)
        {
            foreach (var (from, to) in list)
            {
                if (!Graph.ContainsKey(from))
                {
                    Graph[from] = new List<string>();
                }
                if (!Graph.ContainsKey(to))
                {
                    Graph[to] = new List<string>();
                }
                Graph[from].Add(to);
                Graph[to].Add(from);
            }
        }


        public void BFS(string Start)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(Start);
            HashSet<string> visited = new HashSet<string>();

            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                visited.Add(node);
                Console.WriteLine("Marked visited node is " + node);

                foreach (var nodes in Graph[node])
                {
                    if (!visited.Contains(nodes))
                    {
                        visited.Add(nodes);
                        queue.Enqueue(nodes);
                    }
                }
            }
        }

        public void shortedPathOfFlight(string source, string destination)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(source);
            HashSet<string> visited = new HashSet<string>();

            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                visited.Add(node);
                Console.WriteLine("shorted path travel " + node);
                if (node == destination)
                {
                    break;
                }
                foreach (var nodes in Graph[node])
                {
                    if (!visited.Contains(nodes))
                    {
                        visited.Add(nodes);
                        queue.Enqueue(nodes);
                    }
                }
            }
        }
    }
}
