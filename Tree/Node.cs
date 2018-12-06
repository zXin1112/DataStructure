using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//二叉链表节点
namespace Tree
{
    public class Node<T>
    {
        public T data { get; set; }
        public Node<T> lchild { get; set; }
        public Node<T> rchild { get; set; }
        public Node() { }
        public Node(T data, Node<T> lchild = null, Node<T> rchild = null)
        {
            this.data = data;
            this.lchild = lchild;
            this.rchild = rchild;
        }
    }
    public class Node
    {
        private bool _isOptr;//标识节点是否为字符
        private int _data;//数据
        private Node _left;//左孩子
        private Node _right;//右孩子

        public Node(int data)
        {
            Data = data;

            IsOptr = false;//节点为数字
        }
        public Node(char optr)
        {
            IsOptr = true;//节点为操作符
            Data = optr;
        }

        public bool IsOptr { get => _isOptr; set => _isOptr = value; }
        public int Data { get => _data; set => _data = value; }
        public Node Left { get => _left; set => _left = value; }
        public Node Right { get => _right; set => _right = value; }

        public override string ToString()
        {
            if (IsOptr)//若是操作符
            {
                return Convert.ToString((char)Data);
            }
            else//数字
            {
                return Data.ToString();
            }
        }
    }
}
