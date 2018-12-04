using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//队列
namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("创建一个数组实现的队列：");
            MyArrayQueu<int> myArray = new MyArrayQueu<int>(2);
            Console.WriteLine("添加数据0-4：");
            for (int i = 0; i < 5; i++)
                myArray.EnQueu(i);
            Console.WriteLine("出队四次：");
            for (int i = 0; i < 4; i++)
                Console.Write("{0} ", myArray.DeQueu());
            Console.WriteLine("\r\n当前队列大小：{0}", myArray.Size);
            Console.WriteLine("将数据10入队：");
            myArray.EnQueu(10);
            Console.WriteLine("将所有队中数据出队：");
            for (int i = 0, j = myArray.Size; i < j; i++)
                Console.Write("{0} ", myArray.DeQueu());
            Console.WriteLine("\r\n---------------------------");
            Console.WriteLine("创建一个链表实现的队列：");
            MyLinkQueu<int> myLinkQueu = new MyLinkQueu<int>();
            Console.WriteLine("添加数据0-4：");
            for (int i = 0; i < 5; i++)
                myLinkQueu.EnQueue(i);
            Console.WriteLine("所有数据出队：");
            for (int i = 0, j = myLinkQueu.Size; i < j; i++)
                Console.Write("{0} ", myLinkQueu.DeQueue());
            Console.WriteLine("\r\n当前队列大小：{0}", myArray.Size);
            Console.ReadKey();
        }
    }
    //数组实现
    class MyArrayQueu<T>
    {
        private T[] item;//单个数据元素
        private int size;//队列大小
        private int head;//队头
        private int tail;//队尾

        public MyArrayQueu(int capacticy)
        {
            item = new T[capacticy];
            size = 0;
            head = tail = 0;
        }
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="value"></param>
        public void EnQueu(T value)
        {
            if (size == item.Length) ResizeCapacity(item.Length * 2); //当数组满时，改变大小
            item[tail] = value;//队尾添加值
            tail++;//指向下一个
            size++;
        }
        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T DeQueu()
        {
            if (size == 0) return default(T);
            T retuValue = item[head];//队头
            item[head] = default(T);
            head++;
            if (head > 0 && size == item.Length / 4)
                ResizeCapacity(item.Length / 2);

            size--;

            return retuValue;
        }
        private void ResizeCapacity(int newCapacity)
        {
            T[] newItems = new T[newCapacity];
            int index = 0;
            if (newCapacity > item.Length)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    newItems[index++] = item[i];
                }
            }
            else
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (!item[i].Equals(default(T)))//当值不为空时
                    {
                        newItems[index++] = item[i];
                    }
                }
                //重置队头队尾
                head = 0;
                tail = index;
            }

            item = newItems;

        }
        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsEmpty()
        {
            return this.size == 0;
        }

        /// <summary>
        /// 栈中节点个数
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }
        }
    }
    //队列节点
    class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }
        public Node() { }
        public Node(T item)
        {
            Item = item;
        }
    }
    //队列链表实现
    class MyLinkQueu<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int size;
        public MyLinkQueu()
        {
            size = 0;
            head = tail = null;
        }
        public void EnQueue(T value)
        {
            if (size == 0)
                head = tail = new Node<T>(value);
            else
            {
                tail.Next = new Node<T>(value);
                tail = tail.Next;
            }
            size++;
        }
        public T DeQueue()
        {
            T retuvalue = head.Item;
            head = head.Next;
            size--;
            if (size == 0) tail = null;
            return retuvalue;
        }
        /// <summary>
        /// 是否为空队列
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsEmpty()
        {
            return this.size == 0;
        }

        /// <summary>
        /// 队列中节点个数
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }
        }
    }
}
