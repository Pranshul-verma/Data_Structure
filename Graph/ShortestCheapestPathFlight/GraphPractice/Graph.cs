using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphPractice
{
    internal class Graph
    {
        Dictionary<string, List<String>> Edges;
        HashSet<string> Visited;

        public Graph()
        {
            Edges = new Dictionary<string, List<String>>();
            Visited = new HashSet<string>();

        }

        internal void AddEdgesOfGraph(List<(string, string)> edges)
        {
            foreach (var (from, to) in edges)
            {
                if (!Edges.ContainsKey(from))
                {
                    Edges[from] = new List<string>();
                }
                if (!Edges.ContainsKey(to))
                {
                    Edges[to] = new List<string>();
                }
                Edges[to].Add(from);
                Edges[from].Add(to);
            }
        }

        public void BreathFirstSearch(string start)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                //var last = node.Last();

                //if (!Visited.Contains(node))
                {
                    Console.WriteLine("traveled node is " + node);

                    Visited.Add(node);
                }
                foreach (var neighbour in Edges[node])
                {
                    if (!Visited.Contains(neighbour))
                    {
                        Visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        public void DepthFirstSearch(string Start)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push(Start);
            var visited = new List<string>();
            while (stack.Count() > 0)
            {
                var node = stack.Pop();
                if (!visited.Contains(node))
                {
                    Console.WriteLine("traveled node is " + node);

                    visited.Add(node);
                }
                foreach (var neighbour in Edges[node])
                {
                    if (!visited.Contains(neighbour))
                    {
                        // Visited.Add(neighbour);
                        stack.Push(neighbour);
                    }
                }

            }

        }

        public void FindShortedPath(string Start, string Desitination)
        {
            Queue<List<string>> queue = new Queue<List<string>>();
            Visited = new HashSet<string>();

            queue.Enqueue(new List<string>() { Start });

            while (queue.Count() > 0)
            {
                var path = queue.Dequeue();
                var last = path.Last();
                Visited.Add(last);

                if (last == Desitination)
                {
                    Console.WriteLine("shorted path for flight between source and desitination is " + string.Join("->", path));
                    break;
                }
                foreach (var neighbour in Edges[last])
                {
                    if (!Visited.Contains(neighbour))
                    {
                        Visited.Add(neighbour);
                        queue.Enqueue(new List<string>(path) { neighbour });
                    }
                }
            }
        }


        /// <summary>
        /// Yet not solved...
        /// </summary>
        /// <param name="flightRouteWithPrice"></param>
        /// <param name="Start"></param>
        /// <param name="Desitination"></param>
        public void FindCheapestFlightBetweenSourceAndDestination(List<(string, string, int)> flightRouteWithPrice, string Start, string Desitination)
        {
            var graphEdges = new Dictionary<string, List<(string, int)>>();
            var queue = new Queue<(List<string>, int)>();
            var visited = new Dictionary<List<string>, int>();
            var shortestPath = new PriorityQueue<List<string>, int>();
            var cheapestFlight = new PriorityQueue<List<string>, int>();
            foreach (var (from, to, price) in flightRouteWithPrice)
            {
                if (!graphEdges.ContainsKey(from))
                {
                    graphEdges[from] = new List<(string, int)>();
                }
                if (!graphEdges.ContainsKey(to))
                {
                    graphEdges[to] = new List<(string, int)>();
                }
                var items = new List<(string, int)>(graphEdges[from]) { (to, price) };
                graphEdges[from] = (items);
                items = new List<(string, int)>(graphEdges[to]) { (from, price) };
                graphEdges[to] = (items);
            }
            (List<string>, int) item = new(new List<string> { Start }, 0);
            queue.Enqueue(item);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var path = node.Item1;
                var last = path.Last();
                if (!visited.ContainsKey(node.Item1))
                {
                    visited[node.Item1] = node.Item2;
                }
                if (last == Desitination)
                {
                    shortestPath.Enqueue(path, path.Count());
                    cheapestFlight.Enqueue(path, node.Item2);                    
                }
                foreach (var neighbour in graphEdges[last])
                {
                    if (!CheckKeyExisting(visited, neighbour))
                    {
                        queue.Enqueue((new List<string>(path) { neighbour.Item1 }, node.Item2 + neighbour.Item2));
                    }

                }

            }
            Console.WriteLine("Shorted path will be " + string.Join("->", shortestPath.Dequeue()));
            int cost = 0;
            List<string> flightPath = new List<string>();
            cheapestFlight.TryDequeue(out flightPath, out cost);
            Console.WriteLine("Cheapest flight path will be " + string.Join("->", flightPath) + " and it will cost " + cost);
        }

        private bool CheckKeyExisting(Dictionary<List<string>, int> visited, (string, int) neighbour)
        {
            foreach (var item in visited.Keys)
            {
                if (item.Contains(neighbour.Item1))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

