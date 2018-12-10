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
            Console.WriteLine("\r\n------------最小生成树Prim算法------------");

            int[,] cost = new int[6, 6] {
              {0,6,6,1,0,0},
              {6,0,0,5,3,0},
              {6,0,0,5,0,2},
              {1,5,5,0,6,4},
              {0,3,0,6,0,6},
              {0,0,2,4,6,0}
            };
            PrimTest(cost);
            Console.WriteLine("\r\n------------最小生成树Kruskal算法------------");
            KruskalTest(cost);
            Console.WriteLine("\r\n------------最段路径Dijkstra算法------------");
            DijkstraTest();
            Console.WriteLine("\r\n------------最段路径Floyd算法------------");
            FloydTest();
            Console.ReadKey();
        }
        /// <summary>
        /// Prim算法调用
        /// </summary>
        /// <param name="cost"></param>
        static public void PrimTest(int[,] cost)
        {


            Console.WriteLine("Prim算法构造最小生成树：（从顶点0开始）");
            double sum = 0;
            Prim(cost, 0, ref sum);
            Console.WriteLine("最小生成树权值和为：{0}", sum);
        }

        /// <summary>
        /// Prim算法
        /// </summary>
        /// <param name="V">图</param>
        /// <param name="vertex">起始顶点</param>
        /// <param name="sum">权值</param>
        private static void Prim(int[,] V, int vertex, ref double sum)
        {
            int length = V.GetLength(1);//获取顶点长度
            int[] lowcost = new int[length];//待选边的权值集合
            int[] u = new int[length];//最终生成树

            for (int i = 0; i < length; i++)
            {
                lowcost[i] = V[vertex, i];//将起始顶点的所有邻接点权值取出
                u[i] = vertex;//u集合中的值全为起始点，初始化
            }

            lowcost[vertex] = -1;//起始节点标记为已使用
            for (int i = 1; i < length; i++)
            {
                int k = 0;//记录索引
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
                    //此时刚插入的顶点和其他未选中顶点的权值和结合U中的目前已知最小的权值进行比较，如果小于，则更新权值集合和集合U 
                    {
                        lowcost[j] = V[k, j]; // 更新权值集合，将权值最小的邻边结点的权值插入
                        u[j] = k; // 更新集合U，将权值最小的邻边节点插入到集合中，
                    }
                }
            }
        }

        /// <summary>
        /// Kruskal算法调用
        /// </summary>
        /// <param name="cost">图</param>
        static public void KruskalTest(int[,] cost)
        {
            Console.WriteLine("Kruskal算法构造最小生成树：（从顶点0开始）");
            double sum = 0;
            Kruskal(cost, 0, ref sum);
            Console.WriteLine("最小生成树权值和为：{0}", sum);
        }
        /// <summary>
        /// Kruskal用到的结构
        /// </summary>
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

        /// <summary>
        /// 边的初始化
        /// </summary>
        /// <param name="cost">图</param>
        /// <returns></returns>
        static List<Edge> BuildEdgeList(int[,] cost)
        {
            int length = cost.GetLength(1);//节点个数
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

        /// <summary>
        /// Kruskal算法
        /// </summary>
        /// <param name="cost">图</param>
        /// <param name="vertex">起始顶点</param>
        /// <param name="sum">总权值</param>
        static void Kruskal(int[,] cost, int vertex, ref double sum)
        {
            int length = cost.GetLength(1);//顶点个数
            List<Edge> edgeList = BuildEdgeList(cost); // 获取边的有序集合
            int[] groups = new int[length]; // 存放分组号的辅助数组

            for (int i = 0; i < length; i++)
            {
                // 辅助数组的初始化：每个顶点配置一个唯一的分组号
                groups[i] = i;//由于此算法再加入边时要判断是否为同一连通分量，故分组，同一连通分量为一组
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

        /// <summary>
        /// Dijkstra算法调用
        /// </summary>
        static void DijkstraTest()
        {
            Console.WriteLine("Dijkstra算法构造最短路径：（从顶点0开始）");
            int[,] cost = new int[5, 5];
            // 初始化邻接矩阵
            cost[0, 1] = 10;
            cost[0, 3] = 30;
            cost[0, 4] = 90;
            cost[1, 2] = 50;
            cost[2, 4] = 10;
            cost[3, 2] = 20;
            cost[3, 4] = 60;
            // 使用Dijkstra算法计算最短路径
            Dijkstra(cost, 0);
        }
        /// <summary>
        /// Dijkstra算法
        /// </summary>
        /// <param name="cost">图</param>
        /// <param name="v">起始顶点</param>
        static void Dijkstra(int[,] cost, int v)
        {
            int n = cost.GetLength(1); // 计算顶点个数
            int[] s = new int[n];      // 集合S
            int[] dist = new int[n];   // 结果集
            int[] path = new int[n];   // 路径集

            for (int i = 0; i < n; i++)
            {
                // 初始化结果集
                dist[i] = cost[v, i];
                // 初始化路径集
                if (cost[v, i] > 0)
                {
                    // 如果源点与顶点存在边
                    path[i] = v;
                }
                else
                {
                    // 如果源点与顶点不存在边
                    path[i] = -1;
                }
            }

            s[v] = 1;   // 将源点加入集合S
            path[v] = 0;//原点到原点的权值为0

            for (int i = 0; i < n; i++)
            {
                int u = 0;  // 指示剩余顶点在dist集合中的最小值的索引号
                int minDis = int.MaxValue; // 指示剩余顶点在dist集合中的最小值大小

                // 01.计算dist集合中的最小值
                for (int j = 0; j < n; j++)
                {
                    if (s[j] == 0 && dist[j] > 0 && dist[j] < minDis)
                    {
                        u = j;
                        minDis = dist[j];
                    }
                }

                s[u] = 1; // 将抽出的顶点放入集合S中

                // 02.计算源点经过顶点u到其余顶点的距离
                for (int j = 0; j < n; j++)
                {
                    // 如果顶点不在集合S中
                    if (s[j] == 0)
                    {
                        // 加入的顶点如与其余顶点存在边，并且重新计算的值小于原值
                        if (cost[u, j] > 0 && (dist[j] == 0 || dist[u] + cost[u, j] < dist[j]))
                        {
                            // 计算更小的值代替原值
                            dist[j] = dist[u] + cost[u, j];
                            path[j] = u;
                        }
                    }
                }
            }


            // 打印源点到各顶点的路径及距离
            for (int i = 0; i < n; i++)
            {
                if (s[i] == 1)
                {
                    Console.Write("从{0}到{1}的最短路径为：", v, i);
                    Console.Write(v + "→");
                    // 使用递归获取指定顶点在路径上的前一顶点
                    GetPath(path, i, v);
                    Console.Write(i + Environment.NewLine + "SUM:");
                    Console.WriteLine("路径长度为：{0}", dist[i]);
                }
            }
        }

        /// <summary>
        /// 获取路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="i"></param>
        /// <param name="v"></param>
        static void GetPath(int[] path, int i, int v)
        {
            int k = path[i];
            if (k == v)
            {
                return;
            }

            GetPath(path, k, v);
            Console.Write(k + "→");
        }


        /// <summary>
        /// Floyd算法调用
        /// </summary>
        static public void FloydTest()
        {
            Console.WriteLine("Floyd算法构造最短路径：（从顶点0开始）");
            int[,] cost = new int[5, 5];
            // 初始化邻接矩阵
            cost[0, 1] = 10;
            cost[0, 3] = 30;
            cost[0, 4] = 90;
            cost[1, 2] = 50;
            cost[2, 4] = 10;
            cost[3, 2] = 20;
            cost[3, 4] = 60;
            // 使用Flyod算法计算最短路径
            Floyd(cost, 0);
        }
        /// <summary>
        /// Floyd算法
        /// </summary>
        /// <param name="cost">图</param>
        /// <param name="v">起始顶点</param>
        static void Floyd(int[,] cost, int v)
        {
            int n = cost.GetLength(1);  // 获取顶点个数
            int[,] A = new int[n, n];   // 存放最短路径长度
            int[,] path = new int[n, n];// 存放最短路径信息

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // 辅助数组A和path的初始化
                    A[i, j] = cost[i, j];
                    path[i, j] = -1;
                }
            }

            // Flyod算法核心代码部分
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // 如果存在中间顶点K的路径
                        if (i != j && A[i, k] != 0 && A[k, j] != 0)
                        {
                            // 如果加入中间顶点k后的路径更短
                            if (A[i, j] == 0 || A[i, j] > A[i, k] + A[k, j])
                            {
                                // 使用新路径代替原路径
                                A[i, j] = A[i, k] + A[k, j];
                                path[i, j] = k;
                            }
                        }
                    }
                }
            }

            // 打印最短路径及路径长度
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[i, j] == 0)
                    {
                        if (i != j)
                        {
                            Console.WriteLine("从{0}到{1}没有路径!", i, j);
                        }
                    }
                    else
                    {
                        Console.Write("从{0}到{1}的路径为：", i, j);
                        Console.Write(i + "→");
                        // 使用递归获取指定顶点的路径
                        GetPath(path, i, j);
                        Console.Write(j + "     ");
                        Console.WriteLine("路径长度为：{0}", A[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 获取路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        static void GetPath(int[,] path, int i, int j)
        {
            int k = path[i, j];
            if (k == -1)
            {
                return;
            }

            GetPath(path, i, k);
            Console.Write(k + "→");
            GetPath(path, k, j);
        }
    }
}
