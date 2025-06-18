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

        public void BFS(string start, string destination)
        {
            var queue = new Queue<List<string>>();
            var visited = new HashSet<string>();

            queue.Enqueue(new List<string> { start });
            visited.Add(start);

            while (queue.Count > 0)
            {
                var path = queue.Dequeue();
                string last = path.Last();

                if (last == destination)
                {
                    Console.WriteLine("Shortest path: " + string.Join(" -> ", path));
                    Console.WriteLine("Number of edges: " + (path.Count - 1));
                    return;
                }

                foreach (var neighbor in GraphEdge[last])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        var newPath = new List<string>(path) { neighbor };
                        queue.Enqueue(newPath);
                    }
                }
            }

            Console.WriteLine("No path found.");
        }

    }
}
