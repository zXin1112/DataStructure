using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//单链表
namespace Single_Linked_List
{
    public delegate void printslDel();
    class Program
    {
        static void Main(string[] args)
        {
            MySingleLinkedList<int> linkedList = new MySingleLinkedList<int>();
            linkedList.printSl += () =>
            {
                for (int i = 0; i < linkedList.Count; i++)
                {
                    Console.Write("{0} ", linkedList[i]);
                }
                Console.WriteLine();
            };
            Console.WriteLine("插入:");
            for (int i = 0; i < 5; i++)
            {
                linkedList.Add(i);
            }
            //for (int i = 4; i >= 0; i--)
            //{
            //    linkedList.RemoveAt(i);
            //}

            Console.WriteLine("向头结点插入10:");
            linkedList.Add(0, 10);

            Console.WriteLine("向索引为3插入20:");
            linkedList.Add(3, 20);

            Console.WriteLine("向索引为{0}插入30（最后一个节点）:", linkedList.Count - 1);
            linkedList.Add(linkedList.Count - 1, 30);

            Console.WriteLine("移除头结点:");
            linkedList.RemoveAt(0);

            Console.WriteLine("移除索引为2的节点:");
            linkedList.RemoveAt(2);

            Console.WriteLine("移除索引为{0}的节点（最后一个节点）:", linkedList.Count - 1);
            linkedList.RemoveAt(linkedList.Count - 1);

            Console.ReadKey();
        }
    }
    //单链表节点类
    class Node<T>
    {
        public T item { get; set; }//数据域
        public Node<T> Next { get; set; }//指针域，后继指针


        public Node()
        {
        }
        public Node(T item)
        {
            this.item = item;
        }

    }
    //实现
    class MySingleLinkedList<T>
    {
        public event printslDel printSl;//声明事件，使用自定义委托的事件
        private int count;
        public int Count { get => count; }//链表节点个数

        private Node<T> head;//头结点
        public MySingleLinkedList()
        {
            count = 0;
            head = null;
        }
        public T this[int index] //声明索引器
        {
            get { return GetNodeByIndex(index).item; }
            set { GetNodeByIndex(index).item = value; }
        }
        //返回指定索引index的节点
        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= count)//判断索引大小
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            Node<T> temp = head;//获取头结点，遍历单链表获取index的值
            for (int i = 0; i < index; i++)
                temp = temp.Next;
            return temp;
        }
        /// <summary>
        /// 尾部插入节点
        /// </summary>
        /// <param name="value">添加的值</param>
        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            if (head == null)
                head = node;//若头结点为空，则置为头结点
            else
            {
                Node<T> prevNode = GetNodeByIndex(count - 1);//获取最后一个节点
                prevNode.Next = node;//使尾节点指向要添加的节点
            }
            count++;//链表长度自增
            printSl?.Invoke();//若事件不为空则执行
        }
        /// <summary>
        /// 向指定位置添加节点
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">添加的值</param>
        public void Add(int index, T value)
        {
            Node<T> tempNode = null;
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            else if (index == 0)
            {
                if (head == null)//头结点为空
                    head = new Node<T>(value);
                else//替换头节点
                {
                    tempNode = new Node<T>(value);//创建新节点
                    tempNode.Next = head;//新节点的指针域指向现在的头结点
                    head = tempNode;//头结点指向新节点
                }
            }
            else//不插入头结点且索引未超出界限
            {
                Node<T> prveNode = GetNodeByIndex(index - 1);//获取指定索引的前一个节点

                tempNode = new Node<T>(value);//创建新节点
                tempNode.Next = prveNode.Next;//指定索引的前一个节点的下一个节点赋值给新节点的下一个节点
                prveNode.Next = tempNode;//指定索引的前一个节点的指针域指向新节点
                //前一个节点=》新节点=》原指定索引的节点
            }
            count++;
            printSl?.Invoke();
        }
        /// <summary>
        /// 删除指定索引的节点
        /// </summary>
        /// <param name="index">索引</param>
        public void RemoveAt(int index)
        {
            if (index == 0)
                head = head.Next;//删除头结点，使原头结点的下一个节点成为新的头结点
            else
            {
                Node<T> prveNode = GetNodeByIndex(index - 1);
                if (prveNode.Next == null)//若指定索引的前一个节点的下一个节点为空，则指定节点为空，故索引超出范围
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                Node<T> deleteNode = prveNode.Next;//获取要删除的节点
                prveNode.Next = deleteNode.Next;
                //要删除的节点的前一个节点的指针域 指向要删除节点的指针域 指向的节点
                //前一个节点=》删除节点=》后一个节点    删除前
                //前一个节点=》后一个节点              删除后
                deleteNode = null;
            }
            count--;
            printSl?.Invoke();
        }
    }
}
