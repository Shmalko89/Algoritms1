using System;
using System.Collections;
using System.Collections.Generic;

namespace Algoritms6
{
    public class Node     //Вершина
    {
        public int Value { get; set; }
        public Node(int value)
        {
            Value = value;
        }

    }

    public class Edge //Ребро
    {
        public Node From { get; set; }
        public Node To { get; set; }



        public int Weight { get; set; }

        public Edge(Node from, Node to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }

    public class Graph //Создание ГРафа
    {
        List<Node> Nodes = new List<Node>();
        List<Edge> Edges = new List<Edge>();

        public void AddNodes(Node node) //метод добавления вершины
        {
            Nodes.Add(node);
        }

        public void AddEdge(Node from, Node to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }
        public int[,] GetMatrix()
        {
            var matrix = new int[Nodes.Count, Nodes.Count];

            foreach (var edge in Edges)
            {
                var row = edge.From.Value;
                var column = edge.To.Value;

                matrix[row, column] = edge.Weight;
            }
            return matrix;
        }
        public void DFS(Node start)
        {
            
        }

        class Program
        {

            static void Main(string[] args)
            {
                var graph = new Graph();

                var v1 = new Node(1);
                var v2 = new Node(2);
                var v3 = new Node(3);
                var v4 = new Node(4);
                var v5 = new Node(5);
                var v6 = new Node(6);
                var v7 = new Node(7);
                var v8 = new Node(8);
                var v9 = new Node(9);

                graph.AddNodes(v1);
                graph.AddNodes(v2);
                graph.AddNodes(v3);
                graph.AddNodes(v4);
                graph.AddNodes(v5);
                graph.AddNodes(v6);
                graph.AddNodes(v7);
                graph.AddNodes(v8);
                graph.AddNodes(v9);

                graph.AddEdge(v1, v2);
                graph.AddEdge(v1, v3);
                graph.AddEdge(v2, v4);
                graph.AddEdge(v3, v4);
                graph.AddEdge(v4, v5);
                graph.AddEdge(v4, v6);
                graph.AddEdge(v7, v5);
                graph.AddEdge(v8, v9);
                graph.AddEdge(v8, v7);
                graph.AddEdge(v9, v7);

                



            }
        }
    }
}
