// See https://aka.ms/new-console-template for more information
using GraphDFS;

Console.WriteLine("Hello, World!");

Graph g = new Graph(8);
g.AddEdge(0, 1);
g.AddEdge(1, 2);
g.AddEdge(1, 3);
g.AddEdge(2, 4);
g.AddEdge(2, 5);
g.AddEdge(5, 6);
g.AddEdge(5, 7);
g.AddEdge(3, 5);
g.DFS(0);
Console.ReadLine();

// graph will be like 0
//                    I
//                    1-----3 
//                    I     I
//                    I     I
//                    2-----5----7
//                    I     I
//                    4     6