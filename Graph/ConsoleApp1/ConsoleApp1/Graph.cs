using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Graph
    {
        Dictionary<string, List<string>> GraphEdge;

        public Graph()
        {
            GraphEdge = new Dictionary<string, List<string>>();
        }

        public void Addedge(List<(string, string)> edges)
        {
            foreach (var (from, to) in edges)
            {
                if (!GraphEdge.ContainsKey(from))
                {
                    GraphEdge[from] = new List<string>();
                }
                if (!GraphEdge.ContainsKey(to))
                {
                    GraphEdge[to] = new List<string>();
                }
                GraphEdge[from].Add(to);
                GraphEdge[to].Add(from);
            }
        }


        public void DFS(string Start)
        {            
            Stack<string> stack = new Stack<string>();
            List<string> visited = new List<string>();
            stack.Push(Start);
            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    Console.WriteLine("travel node are " + node);
                }
                foreach (var neighbours in GraphEdge[node])
                {
                    if (!visited.Contains(neighbours))
                        stack.Push(neighbours);
                }
            }
        }

        public void BFS(string start)
        {
            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();


                visited.Add(node);
                Console.WriteLine("travel node are " + node);

                foreach (var neighbours in GraphEdge[node])
                {
                    if (!visited.Contains(neighbours))
                    {
                        visited.Add(neighbours);
                        queue.Enqueue(neighbours);
                    }
                }
            }
        }
    }
}
