using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FindShortest_CheapestFlight
    {
        private Dictionary<string, List<(string, int)>> flightRouteVsFair;

        public FindShortest_CheapestFlight()
        {
            flightRouteVsFair = new();
        }

        public void AddFlightRouteandFair(List<(string, string, int)> info)
        
        {
            foreach (var (from, to, fair) in info)
            {
                if (!flightRouteVsFair.ContainsKey(from))
                {
                    flightRouteVsFair[from] = new List<(string, int)>();
                }
                if (!flightRouteVsFair.ContainsKey(to))
                {
                    flightRouteVsFair[to] = new List<(string, int)>();
                }
                flightRouteVsFair[from].Add((to, fair));
                flightRouteVsFair[to].Add((from, fair));
            }

        }

        public void findShortestandCheapestPath(string source, string destination)
        {
            Queue<List<string>> queue = new Queue<List<string>>();
            HashSet<string> visited = new HashSet<string>();
            List<int> price = new();
            queue.Enqueue(new List<string>() { source });
            while (queue.Count() > 0)
            {
                var path = queue.Dequeue();
               
                visited.Add(path.Last());
                
                if (path.Last() == destination)
                {
                    Console.WriteLine("Shortest path: " + string.Join(" -> ", path));
                    break;
                }
                foreach (var neighbour in flightRouteVsFair[path.Last()])
                {
                    if (!visited.Contains(neighbour.Item1))
                    {

                        visited.Add(neighbour.Item1);
                        var newPath = new List<string>(path) {neighbour.Item1 };
                        queue.Enqueue(newPath);

                    }

                }
            }
           // Console.WriteLine("total price to travel between " + source + " to " + destination + price.Aggregate(0, (total, n) => total + n));

        }
    }
}
