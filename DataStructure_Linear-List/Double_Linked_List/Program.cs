using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//双链表
namespace Double_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {

            MyDoubleLinkedList<int> myDouble = new MyDoubleLinkedList<int>();//创建对象
            myDouble.printDb += (object s, EventArgs e) =>
            {//订阅事件，打印链表中的内容
                for (int i = 0; i < myDouble.Count; i++)
                {
                    Console.Write("{0} ", myDouble[i]);
                }
                Console.WriteLine();
            };//用Lambda表达式注册

            Console.WriteLine("在尾部后插入6个值 AddAfter：");
            for (int i = 0; i < 6; i++)
            {
                myDouble.AddAfter(i);
            }

            Console.WriteLine("在尾部前插入6 AddBefore：");
            myDouble.AddBefore(6);

            Console.WriteLine("向下标为2的节点之后插入7 InsertAfter:");
            myDouble.InsertAfter(2, 7);

            Console.WriteLine("向下标为4之前插入节点8 InsertBefore:");
            myDouble.InsertBefore(4, 8);

            Console.WriteLine("移除下标为5的节点  RemoveAt:");
            myDouble.RemoveAt(5);

            Console.ReadLine();
        }



    }
    //双链表节点定义
    class DbNode<T>
    {
        public T Item { get; set; }//数据
        public DbNode<T> Prve { get; set; }//前驱
        public DbNode<T> Next { get; set; }//后继
        public DbNode() { }
        public DbNode(T Item) { this.Item = Item; }
    }
    //双链表实现
    public class MyDoubleLinkedList<T>
    {
        public event EventHandler printDb;//声明事件，使用系统定义委托EventHandler的事件

        private int count;//链表节点个数
        private DbNode<T> head;//头结点
        public int Count { get => count; }
        public MyDoubleLinkedList()
        {
            count = 0;
            head = null;

        }
        public T this[int index]//索引器
        {
            get { return GetNodedByIndex(index).Item; }
            set { GetNodedByIndex(index).Item = value; }
        }
        //根据索引返回元素
        private DbNode<T> GetNodedByIndex(int index)
        {
            if (index < 0 || index >= count)//索引范围0<=index<count
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            DbNode<T> tempNode = head;//获取头结点
            for (int i = 0; i < index; i++)//向下遍历节点
            {
                tempNode = tempNode.Next;
            }
            return tempNode;//返回找到的节点
        }
        /// <summary>
        /// 向尾部后插入节点
        /// </summary>
        /// <param name="value">插入的元素</param>
        public void AddAfter(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (head == null)//当前链表为空，插入值为表头
                head = newNode;
            else//若不为空
            {
                DbNode<T> lastNode = GetNodedByIndex(count - 1);//获取最后一个节点
                lastNode.Next = newNode;//最后一个节点的后继指向新节点
                newNode.Prve = lastNode;//插入节点的前驱指向原最后一个节点
            }
            count++;

            //if (printDb != null)
            //{              
            //    printDb(this, null);
            //}    

            printDb?.Invoke(this, null);//若事件不为空则执行
        }
        /// <summary>
        /// 在尾部之前插入节点
        /// </summary>
        /// <param name="value"></param>
        public void AddBefore(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (head == null)//当前链表为空，插入值为表头
                head = newNode;
            else//若不为空
            {
                //在倒数第二个节点和最后一个节点之间插入

                DbNode<T> lastNode = GetNodedByIndex(count - 1);//获取最后一个节点
                DbNode<T> prveNode = lastNode.Prve;//获取倒数第二个节点    
                if (prveNode != null)
                {
                    prveNode.Next = newNode;//掉数第二个节点的后继指向新节点
                    newNode.Prve = prveNode;//新节点的前驱指向倒数第二个节点
                }


                newNode.Next = lastNode;//新节点的后继指向最后一个节点
                lastNode.Prve = newNode;//最后一个节点的前驱之间新节点

                if (count < 2 && head.Next == null)//此时0<count<2,改变头部指针。
                    //当链表中只有一个节点时，head无后继，由于在尾部（此时为head）之前添加节点，故使head指向新节点
                    head = newNode;
            }
            count++;
            printDb?.Invoke(this, null);
        }
        /// <summary>
        /// 向指定位置后插入节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertAfter(int index, T value)
        {
            DbNode<T> tempNode;
            if (index == 0)//插入头部
            {
                if (head == null)//头部为空时
                    head = new DbNode<T>(value);
                else//当头部有元素
                {
                    tempNode = new DbNode<T>(value);//要插入的节点
                    tempNode.Next = head.Next;//插入节点的后继指向头部的后继
                    head.Next.Prve = tempNode;//头部后继的前驱指向插入节点

                    tempNode.Prve = head;//插入节点的前驱指向头部
                    head.Next = tempNode;//头部的后继改为插入节点
                }
            }
            else//不插入头部
            {
                //在指定位置后插入
                //指定位置=》后继     插入前
                DbNode<T> prveNode = GetNodedByIndex(index);//获取指定位置的节点 作为 前驱节点
                DbNode<T> NextNode = prveNode.Next;//指定位置节点的后继 作为 后继节点
                tempNode = new DbNode<T>(value);//要插入的节点
                prveNode.Next = tempNode;//前驱的后继 指向 插入节点
                tempNode.Prve = prveNode;//要插入节点的前驱 指向 前驱的后继
                if (NextNode != null)//若后继不为空
                {
                    tempNode.Next = NextNode;//要插入节点的后继 指向 后继
                    NextNode.Prve = tempNode;//后继的前驱 指向 插入节点
                }
                //指定位置（前驱）=》插入节点=》后继  插入后

            }
            count++;
            printDb?.Invoke(this, null);
        }
        /// <summary>
        /// 指定位置之前插入节点
        /// </summary>
        /// <param name="index">指定位置索引</param>
        /// <param name="value">插入的值</param>
        public void InsertBefore(int index, T value)
        {
            DbNode<T> tempNode;
            if (index == 0)
            {
                if (head == null)
                    head = new DbNode<T>(value);
                else
                {

                    tempNode = new DbNode<T>(value);
                    tempNode.Next = head;//新节点的后继指向原头部
                    head.Prve = tempNode;//原头部的前驱指向新节点
                    head = tempNode;//头部指针变成新节点
                }
            }
            else
            {
                //在指定位置前插入
                //前驱=》指定位置（后继）  插入前
                DbNode<T> NextNode = GetNodedByIndex(index);//获取指定节点作为后继
                DbNode<T> PrveNode = NextNode.Prve;//获取指定节点前驱作为前驱
                tempNode = new DbNode<T>(value);//要插入的节点

                tempNode.Next = NextNode;//插入节点的后继 指向 后继
                NextNode.Prve = tempNode;//后继的前驱 指向 要插入的节点

                tempNode.Prve = PrveNode;//插入节点的前驱 指向 前驱
                PrveNode.Next = tempNode;//前驱的后继 指向 要插入节点
                //前驱=》插入节点=》原指定位置（后继）  插入后
            }
            count++;
            printDb?.Invoke(this, null);
        }
        /// <summary>
        /// 移除指定位置元素
        /// </summary>
        /// <param name="index">指定位置索引</param>
        public void RemoveAt(int index)
        {
            if (index == 0)//若要删除头结点
                head = head.Next;//头结点指向原头结点的后继
            else
            {

                DbNode<T> PrveNode = GetNodedByIndex(index - 1);//获取要移除节点的前驱
                if (PrveNode.Next == null)//若要删除的节点不存在
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                DbNode<T> DeleteNode = PrveNode.Next;//获取要删除的节点
                DbNode<T> NextNode = DeleteNode.Next;//获取要删除节点的后继

                PrveNode.Next = NextNode;//要删除的节点的前驱 指向 要删除的节点的后继
                if (NextNode != null)//若要删除的节点的后继存在
                {
                    NextNode.Prve = PrveNode;//要删除的节点的后继的前驱 指向 要删除的节点的前驱
                }
                DeleteNode = null;//删除节点为空
                //前驱=》要删除的节点=》后继 删除前
                //前驱=》后继               删除后
                //if (index < 0 || index >= count)
                //    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                //else
                //{
                //    DbNode<T> deleteNode = GetNodedByIndex(index);
                //    DbNode<T> pNode = deleteNode.Prve;
                //    DbNode<T> NNode = deleteNode.Next;
                //    pNode.Next = NNode;
                //    if (NNode != null)
                //        NNode.Prve = pNode;
                //    deleteNode = null;
                //}
            }
            count--;
            printDb?.Invoke(this, null);
        }
    }
}
