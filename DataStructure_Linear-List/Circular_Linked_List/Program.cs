using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//循环链表
namespace Circular_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCircularLinkedList<int> myCircular = new MyCircularLinkedList<int>();
            Console.WriteLine("添加五个元素：");
            for (int i = 0; i < 5; i++)
            {
                myCircular.Add(i);
            }
            Console.WriteLine(myCircular.GetAllNodes());
            Console.WriteLine("当前节点：");
            Console.WriteLine(myCircular.CurrentItem);
            Console.WriteLine("删除当前节点");
            myCircular.Remove();
            Console.WriteLine(myCircular.GetAllNodes());
            Console.WriteLine("当前节点：");
            Console.WriteLine(myCircular.CurrentItem);
            // myCircular.Remove();
            for (int i = 0,j= myCircular.Count; i <j ; i++)
            {
                myCircular.Remove();
            }

            Console.WriteLine("约瑟夫环问题：");
            Console.WriteLine("请输入人数：");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入第几个人会被选中：");
            int m = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                myCircular.Add(i);
            }
            Console.WriteLine("初始时共有人员：");
          
                Console.Write(myCircular.GetAllNodes());
            string res = string.Empty;
            while (myCircular.Count > 1)
            {
                myCircular.Move(m);
                res += myCircular.CurrentItem + " ";
                myCircular.Remove();
                Console.WriteLine("\r\n当前剩余人员：{0}" , myCircular.GetAllNodes());
                Console.WriteLine("当前开始：{0}", myCircular.CurrentItem);
            }
            Console.WriteLine("出队人员顺序：{0}", res + myCircular.CurrentItem);
            Console.ReadLine();
        }
    }
    //节点定义
    class CirNode<T>
    {
        public T item { get; set; }//数据域
        public CirNode<T> Next { get; set; }//指针域
        public CirNode() { }
        public CirNode(T item)
        {
            this.item = item;
        }
    }//与单链表相同
    //单向循环链表实现
    class MyCircularLinkedList<T>
    {
        private int count;
        public int Count { get => count; }
        private CirNode<T> tail;//尾节点
        private CirNode<T> currentPrev;//使用前驱节点标识当前节点
        public T CurrentItem
        {
            get { return this.currentPrev.Next.item; }
        }
        public MyCircularLinkedList()
        {
            count = 0;
            tail = null;
        }
        public bool IsEmpty()
        {
            return tail == null;
        }
        /// <summary>
        /// 获取指定索引的值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private CirNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            CirNode<T> tempNode = tail.Next;//tail是尾节点，循环链表尾节点Next指向head
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }
            return tempNode;
        }
        /// <summary>
        /// 尾部添加元素
        /// </summary>
        /// <param name="value">添加的值</param>
        public void Add(T value)
        {
            CirNode<T> newNode = new CirNode<T>(value);
            if (tail == null)//空表
            {
                tail = newNode;
                tail.Next = newNode;
                currentPrev = newNode;
            }
            else
            {
                newNode.Next = tail.Next;//新节点的后继指向原尾节点的后继
                tail.Next = newNode;//原尾节点的后继指向新节点

                if (currentPrev == tail)//当前节点的前驱与尾节点相同时
                {
                    currentPrev = newNode;
                }
                tail = newNode;//调整尾节点指向新添加的节点
            }
            count++;
        }
        public void Remove()
        {
            if (tail == null)
            {
                throw new NullReferenceException("链表中没有任何元素");
            }
            else if (count == 1)
            {
                // 只有一个元素时将两个指针置为空
                tail = null;
                currentPrev = null;
            }
            else
            {
                if (currentPrev.Next == tail)
                {
                    // 当删除的是尾指针所指向的节点时
                    tail = currentPrev;
                }
                // 移除当前节点
                currentPrev.Next = currentPrev.Next.Next;
            }

            count--;
        }

        // Method04:获取所有节点信息
        public string GetAllNodes()
        {
            if (count == 0)
            {
                throw new NullReferenceException("链表中没有任何元素");
            }
            else
            {
                CirNode<T> tempNode = tail.Next;
                string result = string.Empty;
                for (int i = 0; i < count; i++)
                {
                    result += tempNode.item + " ";
                    tempNode = tempNode.Next;
                }

                return result;
            }
        }
        public void Move(int step = 1)
        {
            if (step < 1)
            {
                throw new ArgumentOutOfRangeException("step", "移动步数不能小于1");
            }

            for (int i = 1; i < step; i++)
            {
                currentPrev = currentPrev.Next;
            }
        }
    }
}
