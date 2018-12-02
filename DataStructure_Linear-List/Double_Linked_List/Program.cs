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
            MyDoubleLinkedList<int> myDouble = new MyDoubleLinkedList<int>();
            for (int i = 0; i < 6; i++)
            {
                myDouble.AddBefore(i);
            }
            for (int i = 0; i < myDouble.Count; i++)
            {
                Console.Write("{0} ", myDouble[i]);
            }
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
                if (count < 2 || head.Next==null)//此时0<count<2,改变头部指针
                    head = newNode;
            }
            count++;
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
                    tempNode = new DbNode<T>(value);
                    tempNode.Next = head.Next;
                    head.Next.Prve = tempNode;
                    tempNode.Prve = head;
                    head.Next = tempNode;
                }
            }
            else//不插入头部
            {
                //在指定位置后插入

                DbNode<T> prveNode = GetNodedByIndex(index);//获取指定位置的元素作为前驱节点
                DbNode<T> NextNode = prveNode.Next;//指定位置节点的后继作为后继节点
                tempNode = new DbNode<T>(value);//要插入的节点
                prveNode.Next = tempNode;//指定位置节点的后继是要插入节点
                tempNode.Prve = prveNode;//要插入节点的前驱是指定位置的节点
                if (NextNode != null)//若指定位置节点的后继不为空
                {
                    tempNode.Next = NextNode;//要插入节点的后继为指定位置节点的后继
                    NextNode.Prve = tempNode;//指定位置后继节点的前驱为插入节点
                }

            }
            count++;
        }
        /// <summary>
        /// 指定位置之前插入节点
        /// </summary>
        /// <param name="index">指定位置索引</param>
        /// <param name="value">插入的值</param>
        public void AddBefore(int index, T value)
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
                DbNode<T> NextNode = GetNodedByIndex(index);
                DbNode<T> PrveNode = NextNode.Prve;
                tempNode = new DbNode<T>(value);
                tempNode.Next = NextNode;
                NextNode.Prve = tempNode;

                tempNode.Prve = PrveNode;
                PrveNode.Next = tempNode;
            }
            count++;
        }
        /// <summary>
        /// 移除指定位置元素
        /// </summary>
        /// <param name="index">指定位置索引</param>
        public void RemoveAt(int index)
        {
            if (index == 0)
                head = head.Next;
            else
            {

                DbNode<T> PrveNode = GetNodedByIndex(index - 1);
                if (PrveNode.Next == null)
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                DbNode<T> DeleteNode = PrveNode.Next;
                DbNode<T> NextNode = DeleteNode.Next;
                PrveNode.Next = NextNode;
                if (NextNode != null)
                {
                    NextNode.Prve = PrveNode;
                }
                DeleteNode = null;

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
        }
    }
}
