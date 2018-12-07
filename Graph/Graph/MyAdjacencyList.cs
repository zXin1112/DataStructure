using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class MyAdjacencyList<T> where T : class
    {
        private List<Vertex<T>> items;//顶点集合，存放顶点
        public MyAdjacencyList() : this(10) { }//默认集合大小为10

        public MyAdjacencyList(int capacity)//创建指定大小的集合
        {
            items = new List<Vertex<T>>(capacity);
        }

        /// <summary>
        /// 添加一个顶点
        /// </summary>
        /// <param name="item"></param>
        public void AddVertex(T item)
        {
            if (Contains(item))//是否存在相同的顶点
                throw new ArgumentException("添加了重复的定点");
            Vertex<T> newVertex = new Vertex<T>(item);
            items.Add(newVertex);//将顶点加入到顶点集合中
        }

        /// <summary>
        /// 添加无向图
        /// </summary>
        /// <param name="from">头结点</param>
        /// <param name="to">尾节点</param>
        public void AddEdge(T from, T to)
        {
            Vertex<T> fromVertex = Find(from);//查找节点
            if (fromVertex == null) throw new ArgumentException("头顶点不存在");
            Vertex<T> toVertex = Find(to);//查找节点
            if (toVertex == null) throw new ArgumentException("尾顶点不存在");

            AddDirectedEdge(fromVertex, toVertex);//无向边两个顶点个都要记录信息
            AddDirectedEdge(toVertex, fromVertex);
        }
        /// <summary>
        /// 添加有向边
        /// </summary>
        /// <param name="fromVertex">头顶点</param>
        /// <param name="tovertex">尾顶点</param>
        private void AddDirectedEdge(Vertex<T> fromVertex, Vertex<T> tovertex)
        {
            if (fromVertex.firstEdge == null) fromVertex.firstEdge = new Node(tovertex);//查看邻接表链表的头指针是否为空，为空则添加，使其成为邻接表的头指针
            else
            {
                Node temp = null;//临时变量
                Node node = fromVertex.firstEdge;//找到邻接表的头指针
                do
                {
                    if (node.adjvex.data.Equals(tovertex.data)) throw new ArgumentException("添加了重复的边");//查看是否重复
                    temp = node;
                    node = node.next;//到下一个顶点，检查是否重复
                } while (node != null);
                //与所有顶点不重复
                Node newNode = new Node(tovertex);//创建邻接表节点
                temp.next = newNode;//加入到最后一个节点的后面
            }

        }
        /// <summary>
        /// 添加有向图
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
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
        /// <summary>
        /// 将图中的顶点遍历出来
        /// </summary>
        /// <param name="isDirectedGraph">有向图还是无向图</param>
        /// <returns></returns>
        public string GetGraphInfo(bool isDirectedGraph = false)
        {
            StringBuilder sb = new StringBuilder();//要输出的字符串
            foreach (Vertex<T> v in items)//遍历结合
            {
                sb.Append(v.data.ToString() + ":");//集合中的顶点
                if (v.firstEdge != null)//有边
                {
                    Node temp = v.firstEdge;
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

        /// <summary>
        /// 查找图中是否包含某种元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool Contains(T item)
        {
            foreach (Vertex<T> v in items)//遍历顶点集合
            {
                if (v.data.Equals(item))//有相同的值
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// 查找顶点
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Vertex<T> Find(T item)
        {
            foreach (var v in items)//遍历顶点集合
            {
                if (v.data.Equals(item)) return v;//找到返回
            }
            return null;
        }
        /// <summary>
        /// 存放于集合的表头节点
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        protected class Vertex<TValue>
        {
            public TValue data;//数据
            public Node firstEdge;//邻接点链表头指针
            public bool isVisited;//访问标志，遍历时使用

            public Vertex()
            {
                data = default(TValue);
            }
            public Vertex(TValue value)
            {
                data = value;
            }
        }
        /// <summary>
        /// 链表中的表节点
        /// </summary>
        protected class Node
        {
            public Vertex<T> adjvex;//邻接点域
            public Node next;//下一个邻接点指针域
            public Node()
            {
                adjvex = null;
            }
            public Node(Vertex<T> value)
            {
                adjvex = value;
            }
        }

        /// <summary>
        /// 深度优先遍历
        /// </summary>
        public void DFSTraverse()
        {
            InitVisited();
            DFS(items[0]);
        }

        /// <summary>
        /// 深度优先
        /// </summary>
        /// <param name="vertex"></param>
        private void DFS(Vertex<T> vertex)
        {
            vertex.isVisited = true;//设置已访问该顶点
            Console.Write("{0} ", vertex.data);//输出
            Node node = vertex.firstEdge;//获取该顶点的第一个邻接链表节点

            while (node != null)
            {
                if (!node.adjvex.isVisited)     DFS(node.adjvex);//若未被访问，则递归访问              
                node = node.next;//进入下一个邻接链表节点
            }
        }

        /// <summary>
        /// 深度优先遍历接口For非联通图
        /// </summary>
        public void DFSTraverse4NUG()
        {
            InitVisited();
            foreach (var v in items)
            {
                if (v.isVisited == false)
                {
                    DFS(v);
                }
            }
        }

        /// <summary>
        /// 广度优先
        /// </summary>
        public void BFSTraverse()
        {
            InitVisited();
            BFS(items[0]);
        }

        /// <summary>
        /// 广度优先遍历
        /// </summary>
        /// <param name="vertex"></param>
        private void BFS(Vertex<T> vertex)
        {
            vertex.isVisited = true;
            Console.Write("{0} ", vertex.data);
            Queue<Vertex<T>> vertices = new Queue<Vertex<T>>();
            vertices.Enqueue(vertex);

            while (vertices.Count > 0)//将所有顶点循环出来
            {
                Node node = vertices.Dequeue().firstEdge;
                while (node != null)//将顶点的邻接顶点加入到队列中
                {
                    if (!node.adjvex.isVisited)//若未被读取
                    {
                        node.adjvex.isVisited = true;
                        Console.Write("{0} ", node.adjvex.data);
                        vertices.Enqueue(node.adjvex);
                    }
                    node = node.next;
                }
            }
        }
        /// <summary>
        /// 广度优先遍历接口For非联通图
        /// </summary>
        public void BFSTraverse4NUG()
        {
            InitVisited();
            foreach (var v in items)
            {
                if (v.isVisited == false)
                {
                    BFS(v);
                }
            }
        }


        /// <summary>
        /// 将所有节点设置为未读
        /// </summary>
        private void InitVisited()
        {
            foreach (var item in items)
            {
                item.isVisited = false;
            }
        }
    }
}
