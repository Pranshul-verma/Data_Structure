// See https://aka.ms/new-console-template for more information
using GraphPractice;
using System;
using System.Linq;
using System.Numerics;

Console.WriteLine("Hello, World!");

var edges = new List<(string, string)>() {
("A", "B"),
("B", "C"),
("B", "D"),
("C", "E"),
("B", "F"),
("F", "G"),
("F", "H"),
("D", "F"),
};

Graph g = new Graph();
g.AddEdgesOfGraph(edges);
Console.WriteLine("Breath first Search traversal");
g.BreathFirstSearch("A");

Console.WriteLine("Depth first Search traversal");
g.DepthFirstSearch("A");

Console.WriteLine("Find Shortest path between Source and destination ");
g.FindShortedPath("A", "G");

var graphedges = new List<(string, string, int)>() {
("A", "B",100),
("B", "C",100),
("A","C",500)
};
g.FindCheapestFlightBetweenSourceAndDestination(graphedges,"A", "C");
// A--B
// |
// |
// C
Console.WriteLine("Create fabonacci series of 15");

var result = Enumerable.Range(0, 15).Aggregate(new List<int> { 0, 1 }, (list, Index) =>
{
    if (list.Count <= Index)
        list.Add(list[^1] + list[^2]);
    return list;
});
Console.WriteLine(string.Join(",", result));

var v = Enumerable.Range(1, 20).Aggregate(new BigInteger(1), (total, n) =>  total * n );

Console.WriteLine("Factorial of 20 is "+ v);


Console.ReadLine();