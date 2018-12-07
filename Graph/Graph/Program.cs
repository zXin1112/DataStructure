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
            Console.WriteLine("\r\n------------Prim算法生成最小树------------");
         
            int[,] cost = new int[6, 6] {
              {0,6,6,1,0,0},
              {6,0,0,5,3,0},
              {6,0,0,5,0,2},
              {1,5,5,0,6,4},
              {0,3,0,6,0,6},
              {0,0,2,4,6,0}
            };
            PrimTest(cost);
            Console.WriteLine("\r\n------------ Kruskal算法生成最小树------------");
            KruskalTest(cost);
            Console.ReadKey();
        }
        static public void PrimTest(int[,] cost)
        {
          
           
            Console.WriteLine("Prim算法构造最小生成树：（从顶点0开始）");
            double sum = 0;
            Prim(cost, 0, ref sum);
            Console.WriteLine("最小生成树权值和为：{0}", sum);
        }

        private static void Prim(int[,] V, int vertex, ref double sum)
        {
            int length = V.GetLength(1);
            int[] lowcost = new int[length];//待选边的权值集合
            int[] u = new int[length];//最终生成树

            for (int i = 0; i < length; i++)
            {
                lowcost[i] = V[vertex, i];//将起始顶点的所有邻接点权值取出
                u[i] = vertex;//u集合中的值全为起始点
            }

            lowcost[vertex] = -1;//其实节点标记为已使用
            for (int i = 1; i < length; i++)
            {
                int k = 0;
                int min = int.MaxValue;//最小值
                for (int j = 0; j < length; j++)
                {
                    if (lowcost[j] > 0 && lowcost[j] < min)//找到最小值
                    {
                        min = lowcost[j];//最小权值
                        k = j;//记录最小值索引，即最小值的顶点
                    }
                }
                Console.WriteLine("找到边({0},{1})权为：{2}", u[k], k, min);
                lowcost[k] = -1;  // 标志为已使用
                sum += min; // 累加权值
                for (int j = 0; j < length; j++)
                {
                    if (V[k, j] != 0 && (lowcost[j] == 0 || V[k, j] < lowcost[j]))
                    {
                        lowcost[j] = V[k, j]; // 更新权值集合，将权值最小的邻边结点的权值插入
                        u[j] = k; // 更新集合U，将权值最小的邻边节点插入到集合中，可能多个  
                    }
                }
            }
        }
        static public void KruskalTest(int[,] cost)
        {
            Console.WriteLine("Kruskal算法构造最小生成树：（从顶点0开始）");
            double sum = 0;
            Kruskal(cost, 0, ref sum);
            Console.WriteLine("最小生成树权值和为：{0}", sum);
        }
        
        struct Edge : IComparable
        {
            public int Begin;  // 边的起点
            public int End;    // 边的终点
            public int Weight; // 边的权值

            public Edge(int begin, int end, int weight)
            {
                Begin = begin;
                End = end;
                Weight = weight;
            }

            public int CompareTo(object obj)
            {
                Edge edge = (Edge)obj;
                return Weight.CompareTo(edge.Weight);
            }
        }
        static List<Edge> BuildEdgeList(int[,] cost)
        {
            int length = cost.GetLength(1);
            List<Edge> edgeList = new List<Edge>(); // 边集合
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (cost[i, j] > 0)
                    {
                        if (i < j) // 将序号较小的顶点放在前面
                        {
                            Edge newEdge = new Edge(i, j, cost[i, j]);
                            edgeList.Add(newEdge);
                        }
                        else
                        {
                            Edge newEdge = new Edge(j, i, cost[i, j]);
                            edgeList.Add(newEdge);
                        }
                    }
                }
            }
            edgeList.Sort(); // 让各边按权值从小到大排序
            return edgeList;
        }
        static void Kruskal(int[,] cost, int vertex, ref double sum)
        {
            int length = cost.GetLength(1);
            List<Edge> edgeList = BuildEdgeList(cost); // 获取边的有序集合
            int[] groups = new int[length]; // 存放分组号的辅助数组

            for (int i = 0; i < length; i++)
            {
                // 辅助数组的初始化：每个顶点配置一个唯一的分组号
                groups[i] = i;
            }

            for (int k = 1, j = 0; k < length; j++)
            {
                int begin = edgeList[j].Begin; // 边的起始顶点
                int end = edgeList[j].End; // 边的结束顶点
                int groupBegin = groups[begin]; // 起始顶点所属分组号
                int groupEnd = groups[end]; // 结束顶点所属分组号
                // 判断是否存在回路：通过分组号来判断->不是一个分组即不存在回路
                if (groupBegin != groupEnd)
                {
                    // 打印最小生成树边的信息
                    Console.WriteLine("找到边（{0},{1}）权值为：{2}", begin, end, edgeList[j].Weight);
                    sum += edgeList[j].Weight; // 权值之和累加
                    k++;
                    for (int i = 0; i < length; i++)
                    {
                        // 两棵树合并为一课后，将树的所有顶点所属分组号设为一致
                        if (groups[i] == groupEnd)
                        {
                            groups[i] = groupBegin;
                        }
                    }
                }
            }
        }
    }
}
