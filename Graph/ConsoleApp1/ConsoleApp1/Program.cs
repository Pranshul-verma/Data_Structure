// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

Graph g = new Graph();
var v = new List<(string, string)>()
{
    ("A","B"),
    ("B","C"),
    ("B","H"),
    ("C","E"),
    ("H","E"),
    ("C","D"),
    ("E","F"),
    ("E","G")
};
g.Addedge(v);
g.DFS("A");
g.BFS("A","E");
FindShortest_CheapestFlight obj = new FindShortest_CheapestFlight();
var flights = new List<(string, string, int)>
{
    ("A", "B", 100),
    ("B", "C", 100),
    ("A", "C", 500)
};
obj.AddFlightRouteandFair(flights);
obj.findShortestandCheapestPath("A", "C");
Console.ReadLine();
