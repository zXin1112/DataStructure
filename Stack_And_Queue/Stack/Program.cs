using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("创建一个基于数组的栈：");
            MyArrayStack<int> myArray = new MyArrayStack<int>(5);
            Console.WriteLine("入栈0-4：");
            for (int i = 0; i < 5; i++)
            {
                myArray.Push(i);
            }
            Console.WriteLine("出栈1次：");
            Console.WriteLine(myArray.Pop());
            Console.WriteLine("入栈10：");
            myArray.Push(10);
            Console.WriteLine("所有元素出栈：");
            for (int i = 0,j= myArray.Size; i < j; i++)
                Console.Write("{0} ",myArray.Pop());

            Console.WriteLine("\r\n---------------------------");

            Console.WriteLine("创建一个基于链表的栈：");
            MyLinkStack<int> myLinkStack = new MyLinkStack<int>();
            Console.WriteLine("入栈0-4：");
            for (int i = 0; i < 5; i++)
            {
                myLinkStack.Push(i);
            }
            Console.WriteLine("出栈1次：");
            Console.WriteLine(myLinkStack.Pop());
            Console.WriteLine("入栈10：");
            myLinkStack.Push(10);
            Console.WriteLine("所有元素出栈：");
            for (int i = 0, j = myLinkStack.Size; i < j; i++)
                Console.Write("{0} ", myLinkStack.Pop());
            Console.ReadKey();
        }
    }
    //基于数组的栈
    public class MyArrayStack<T>
    {
        private T[] nodes;//数据元素
        private int index;//索引，索引在每次入栈出栈后，会指向最后一个元素的后一个位置

        public MyArrayStack(int capacity)
        {
            nodes = new T[capacity];
            index = 0;
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="node"></param>
        public void Push(T node)
        {
            if (index == nodes.Length)//栈满
            {
                ResizeCapacity(index * 2);//改变栈的大小
            }
            nodes[index] = node;
            index++;
        }
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (index == 0)//索引为0时是空栈
                return default(T);
            T node = nodes[index - 1];//获取最后一个元素
            index--;
            nodes[index] = default(T);
            if (index > 0 && index == nodes.Length / 4)//判断栈的大小
            {
                ResizeCapacity(nodes.Length / 2);//改变大小
            }
            return node;
        }
        /// <summary>
        /// 改变栈的大小
        /// </summary>
        /// <param name="newCapacity">栈的大小</param>
        private void ResizeCapacity(int newCapacity)
        {
            T[] newnodes = new T[newCapacity];//创建新栈
            if (newCapacity > nodes.Length)    //若新栈的大小比原栈大  
                newCapacity = nodes.Length;      //当新栈比原栈大时，将所有原栈的值转移到新栈；
            //当新栈比原栈小时，按照新栈的大小将原栈的值迁移过来，防止溢出

            for (int i = 0; i < newCapacity; i++)
                newnodes[i] = nodes[i];

            nodes = newnodes;
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return index == 0;
        }
        /// <summary>
        /// 获取栈的大小
        /// </summary>
        public int Size
        {
            get
            {
                return index;
            }
        }
    }
    //节点定义
    class Node<T>
    {
        public T item { get; set; }
        public Node<T> Next { get; set; }
        public Node() { }
        public Node(T item)
        {
            this.item = item;
        }
    }
    //基于链表的栈
    class MyLinkStack<T>{
        private Node<T> first;
        private int index;
        public MyLinkStack()
        {
            first = null;
            index = 0;
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {

            Node<T> newnode = new Node<T>(value);//生成新节点
            newnode.Next = first;//新节点的后继指向表头
            first = newnode;//新节点成为新的表头

            //Node<T> oldNode = first;
            //first = new Node<T>(value);
            //first.Next = oldNode;
            index++;
        }
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T value = first.item;//获取要弹出的值
            first = first.Next;//表头指向下一个元素
            index--;
            return value;
        }
        public bool IsEmpty()
        {
            return index == 0;
        }
        public int Size
        {
            get { return index; }
        }
    }
}
