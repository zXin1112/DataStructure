using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------无向图------------");
            MyAdjacencyList<string> adjList = new MyAdjacencyList<string>();
            // 添加顶点
            adjList.AddVertex("A");
            adjList.AddVertex("B");
            adjList.AddVertex("C");
            adjList.AddVertex("D");
            //adjList.AddVertex("D"); // 会报异常：添加了重复的节点
            // 添加无向边
            adjList.AddEdge("A", "B");
            adjList.AddEdge("A", "C");
            adjList.AddEdge("A", "D");
            adjList.AddEdge("B", "D");
            //adjList.AddEdge("B", "D"); // 会报异常：添加了重复的边

            Console.Write(adjList.GetGraphInfo());

            Console.WriteLine("------------有向图------------");
            MyAdjacencyList<string> dirAdjList = new MyAdjacencyList<string>();
            // 添加顶点
            dirAdjList.AddVertex("A");
            dirAdjList.AddVertex("B");
            dirAdjList.AddVertex("C");
            dirAdjList.AddVertex("D");
            // 添加有向边
            dirAdjList.AddDirectedEdge("A", "B");
            dirAdjList.AddDirectedEdge("A", "C");
            dirAdjList.AddDirectedEdge("A", "D");
            dirAdjList.AddDirectedEdge("B", "D");

            Console.Write(dirAdjList.GetGraphInfo(true));

            MyAdjacencyList<string> myAdjacencyList = new MyAdjacencyList<string>();
            for (int i = 1; i < 9; i++)
                myAdjacencyList.AddVertex("V" + i.ToString());//添加顶点

            //添加无向边
            myAdjacencyList.AddEdge("V1", "V2");
            myAdjacencyList.AddEdge("V1", "V3");

            myAdjacencyList.AddEdge("V2", "V4");
            myAdjacencyList.AddEdge("V2", "V5");

            myAdjacencyList.AddEdge("V3", "V6");
            myAdjacencyList.AddEdge("V3", "V7");

            for (int i = 4; i < 8; i++)
                myAdjacencyList.AddEdge("V" + i.ToString(), "V8");
            Console.WriteLine("------------深度优先遍历------------");
            myAdjacencyList.DFSTraverse();
            Console.WriteLine("\r\n------------非连通图深度优先遍历------------");
            myAdjacencyList.DFSTraverse4NUG();
            Console.WriteLine("\r\n------------广度优先遍历------------");
            myAdjacencyList.BFSTraverse();
            Console.WriteLine("\r\n------------非连通图广度优先遍历------------");
            myAdjacencyList.BFSTraverse4NUG();

            Console.ReadKey();
        }
    }
}
