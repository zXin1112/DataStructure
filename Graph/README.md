# 图

## 定义
图（Graph）是由顶点的有穷非空集合和顶点之间边的集合组成，通常表示为：G(V,E)，其中，G表示一个图，V是图G中顶点的集合，E是图G中边的集合。

**在图中需要注意**：

* 线性表中数据元素叫元素，树中叫结点，在图中数据元素，则称之为顶点（Vertex）。

* 线性表可以没有元素，称为空表；树中可以没有节点，称为空树；但是，在图中不允许没有顶点（有穷非空性）。

* 线性表中的各元素是线性关系，树中的各元素是层次关系，而图中各顶点的关系是用边来表示（边集可以为空）。

## 图中的部分术语

1. 无向图 图中任意两个顶点之间的边都是无向边
	![](https://i.imgur.com/KQooFez.png)
2. 有向图 图中任意两个顶点之间的边都是有向边
	![](https://i.imgur.com/NetQjZJ.png)
3. 完全图
	1. 无向完全图 在无向图中，如果任意两个顶点之间都存在边
		![](https://i.imgur.com/WwpyqTN.png)
	2. 有向完全图 在有向图中，如果任意两个顶点之间都存在方向互为相反的两条弧
		![](https://i.imgur.com/7L5SBmO.png)
	3. 一个图接近完全图时，则称它为稠密图（Dense Graph），而当一个图含有较少的边时，则称它为稀疏图（Spare Graph）。
4. 顶点的度 
	1. 顶点Vi的度（Degree）是指在图中与Vi相关联的边的条数。对于有向图来说，有入度（In-degree）和出度（Out-degree）之分，有向图顶点的度等于该顶点的入度和出度之和。
5. 邻接
	1. 若无向图中的两个顶点V1和V2存在一条边(V1,V2)，则称顶点V1和V2邻接（Adjacent）
	2. 若有向图中存在一条边<V3,V2>，则称顶点V3与顶点V2邻接，且是V3邻接到V2或V2邻接V3
	3. 无向图中的边使用小括号“()”表示，而有向图中的边使用尖括号“<>”表示
6. 路径
	1. 在无向图中，若从顶点Vi出发有一组边可到达顶点Vj，则称顶点Vi到顶点Vj的顶点序列为从顶点Vi到顶点Vj的路径（Path）
7. 连通
	1. 　若从Vi到Vj有路径可通，则称顶点Vi和顶点Vj是连通（Connected）的
8. 权
	1. 有些图的边或弧具有与它相关的数字，这种与图的边或弧相关的数叫做权（Weight）。
	![](https://i.imgur.com/X1DHtWG.png)

## 图的存储结构
1. 邻接矩阵表示法
图的邻接矩阵（Adjacency Matrix）存储方式是用两个数组来表示图。一个一维数组存储图中顶点信息，一个二维数组（称为邻接矩阵）存储图中的边或弧的信息。
	1. 无向图：
		![](https://i.imgur.com/XBgAJsm.png)
	2. 有向图：
		![](https://i.imgur.com/MU2uHry.png)
**不足**：  
由于存在n个顶点的图需要n*n个数组元素进行存储，当图为稀疏图时，使用邻接矩阵存储方法将会出现大量0元素，这会造成极大的空间浪费。这时，可以考虑使用邻接表表示法来存储图中的数据。

2. 邻接表表示法
邻接表由表头节点和表节点两部分组成，图中每个顶点均对应一个存储在数组中的表头节点。如果这个表头节点所对应的顶点存在邻接节点，则把邻接节点依次存放于表头节点所指向的单向链表中。
	1. 无向图：
		![](https://i.imgur.com/GtZA1n9.png)
	2. 有向图：
		![](https://i.imgur.com/nOQBClY.png)
	3. 带权图：对于带权值的网图，可以在边表结点定义中再增加一个weight的数据域，存储权值信息即可
		![](https://i.imgur.com/X4GIcFC.png)

### 基本方法
1. 添加顶点

		 public void AddVertex(T item)
	        {
	            if (Contains(item))//是否存在相同的顶点
	                throw new ArgumentException("添加了重复的定点");
	            Vertex<T> newVertex = new Vertex<T>(item);
	            items.Add(newVertex);//将顶点加入到顶点集合中
	        }
2. 添加边

		  private void AddDirectedEdge(Vertex<T> fromVertex, Vertex<T> tovertex)
		        {
					//检查邻接表链表的头指针是否为空，为空则添加，使其成为邻接表的头指针
		            if (fromVertex.firstEdge == null) fromVertex.firstEdge = new Node(tovertex);
		            else
		            {
		                Node temp = null;//临时变量
		                Node node = fromVertex.firstEdge;//找到邻接表的头指针
		                do
		                {	//检查是否重复
		                    if (node.adjvex.data.Equals(tovertex.data)) throw new ArgumentException("添加了重复的边");
		                    temp = node;
		                    node = node.next;//到下一个顶点，再循环检查是否重复
		                } while (node != null);
		                //与所有顶点不重复
		                Node newNode = new Node(tovertex);//创建邻接表节点
		                temp.next = newNode;//加入到最后一个节点的后面
		            }
		
		        }
	1. 无向图
	
			 public void AddEdge(T from, T to)
	        {
	            Vertex<T> fromVertex = Find(from);//查找节点
	            if (fromVertex == null) throw new ArgumentException("头顶点不存在");
	            Vertex<T> toVertex = Find(to);//查找节点
	            if (toVertex == null) throw new ArgumentException("尾顶点不存在");
	
	            AddDirectedEdge(fromVertex, toVertex);//无向边两个顶点个都要记录信息
	            AddDirectedEdge(toVertex, fromVertex);
	        }
	2. 有向图
	
			 public void AddDirectedEdge(T from, T to)
	        {
	            Vertex<T> fromVertex = Find(from);//查找节点
	            if (fromVertex == null)
	            {
	                throw new ArgumentException("头顶点不存在！");
	            }
	
	            Vertex<T> toVertex = Find(to);//查找节点
	            if (toVertex == null)
	            {
	                throw new ArgumentException("尾顶点不存在！");
	            }
	
	            AddDirectedEdge(fromVertex, toVertex);//有向边有方向，只添加一个
	        }


3. 打印顶点及其邻接点

		   public string GetGraphInfo(bool isDirectedGraph = false)
		        {
		            StringBuilder sb = new StringBuilder();//要输出的字符串
		            foreach (Vertex<T> v in items)//遍历顶点集合
		            {
		                sb.Append(v.data.ToString() + ":");//集合中的顶点取值
		                if (v.firstEdge != null)//有边
		                {
		                    Node temp = v.firstEdge;//获取邻接表第一个节点
		                    while (temp != null)//不为空
		                    {
		                        if (isDirectedGraph)//有向边
		                        {
		                            sb.Append(v.data.ToString() + "→" + temp.adjvex.data.ToString() + " ");
		                        }
		                        else//无向边
		                        {
		                            sb.Append(temp.adjvex.data.ToString());
		                        }
		                        temp = temp.next;//下一个邻接链表中的节点
		                    }
		                }
		                sb.Append("\r\n");
		            }
		            return sb.ToString();
		        }

### 遍历方法

* 深度优先遍历

**原理：** 从图中的某个顶点V出发，访问此顶点，然后从其未被访问的邻接点出发，深度优先遍历图，直至图中所有和V有相同路径的顶点都被访问

![](https://i.imgur.com/iUhnQ9r.png)

* 广度优先遍历

**原理：**从图中的一个顶点出发，访问后依次访问其每一个没有被访问过的邻接点，然后分别以这些邻接点出发，直至所有顶点被访问

![](https://i.imgur.com/tYpz3ck.png)


### 生成树与最小生成树

#### 生成树
* 对于一个无向图，含有连通图全部顶点的一个极小连通子图成为生成树，其本质就是从连通图任一顶点出发进行遍历操作所经过的边，加上所有顶点构成的子图。  
* 采用深度优先遍历获得的生成树称为深度优先生成树（DFS生成树），采用广度优先遍历获得的生成树称为广度优先生成树（BFS生成树）。
#### 最小生成树
如果是一个连通网，则该网所有生成树中权值和最小的生成树为最小生成树

##### 最小生成树算法
* Prim算法
	* 算法思想
		* 假设N={V,{E}}是连通网，TE是N上最小生成树集合。算法从U={u0}(u0∈V),TE={}开始。重复执行以下操作： 在所有u∈U,v∈V-U的边(u,v)∈E中找一条权值最小的边(u0,v0)并入集合，同时v并入U直到U=V为止，此时U有n-1条边，则T={V,{TE}}是N的最小生成树
	* 实现

				private static void Prim(int[,] V, int vertex, ref double sum)
			        {
			            int length = V.GetLength(1);//获取数组长度
			            int[] lowcost = new int[length];//待选边的权值集合
			            int[] u = new int[length];//最终生成树
			
			            for (int i = 0; i < length; i++)
			            {
			                lowcost[i] = V[vertex, i];//将起始顶点的所有邻接点权值取出
			                u[i] = vertex;//u集合中的值全为起始点
			            }
			
			            lowcost[vertex] = -1;//使节点标记为已使用
			            for (int i = 1; i < length; i++)//已有下标为0的顶点故从1开始
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


* Kruskal算法
	* 算法思想
		* Kruskal算法是一种按权值的递增顺序来选择合适的边来构造最小生成树的方法。假设N=(V,{E})是连通网，则令最小生成树的初始状态为只有n个顶点而无边的非连通图T={V,{}}，图中每个顶点自成一个连通分量。在E中选择代价最小的边，若该边依附的顶点落在T中不同的连通分量上，则将此边加入到T中，否则舍去此边而选择下一条代价最小的边。依次类推，直至T中所有顶点都在同一连通分量上为止。
		
	**连通分量：**无向图G的极大连通子图称为G的连通分量( Connected Component)。 任何连通图的连通分量只有一个，即是其自身，非连通的无向图有多个连通分量。
	* 若V(G)中任意两个不同的顶点vi和vj都连通(即有路径)，则称G为连通图(Con-nected Graph)。  
	图G2，和G3是连通图。  
	![](https://i.imgur.com/AcnSBw2.png)  
	* 下图中的G4是非连通图，它有两个连通分量H1和H2。   
	![](https://i.imgur.com/hIoCxX0.png)
	* 实现

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