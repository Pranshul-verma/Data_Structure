// See https://aka.ms/new-console-template for more information
using GraphBFS;

Console.WriteLine("Hello, World!");

GraphBreathFirstSearch obj = new();
var edges = new List<(string, string)>
        {
            ("A", "B"),
            ("A", "C"),
            ("B", "D"),
            ("C", "D"),
            ("D", "E")
        };
obj.Edges(edges);

obj.BFS("A");
obj.shortedPathOfFlight("A", "D");
Console.ReadLine();


