using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDFS
{
    internal class Graph
    {
        private int vertex;

        private List<int>[] edges;

        public Graph(int numberofVertex)
        {
           vertex = numberofVertex;
            edges = new List<int>[vertex];
            for (int i = 0; i < numberofVertex; i++)
            {
                edges[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int e)
        {
            edges[v].Add(e); // Add v to e's list
        }

        public void DFS(int start)
        {

            bool[] visited = new bool[vertex];
            Stack<int> stack = new Stack<int>();

            stack.Push(start);

            while (stack.Count>0)
            {
                var node = stack.Pop();
                if (!visited[node])
                {
                    Console.WriteLine("traverse Node " + node);
                    visited[node] = true;
                }

                foreach (var item in edges[node])
                {
                    if (!visited[item])
                    {
                        stack.Push(item);
                    }
                }
            }
                
        }
    }
}
