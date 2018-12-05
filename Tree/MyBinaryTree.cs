using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//二叉链表实现
namespace Tree
{
    public class MyBinaryTree<T>
    {
        private Node<T> root;

        public Node<T> Root { get => root; }//根节点

        public MyBinaryTree() { }
        public MyBinaryTree(T data) { root = new Node<T>(data); }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return root == null;
        }
        /// <summary>
        /// 为节点添加左子节点
        /// </summary>
        /// <param name="p">为p添加子节点</param>
        /// <param name="data">添加的值</param>
        public void InsertLeft(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            tempNode.lchild = p.lchild;
            p.lchild = tempNode;
        }
        /// <summary>
        /// 为节点添加右子节点
        /// </summary>
        /// <param name="p">为p添加子节点</param>
        /// <param name="data">添加的值</param>
        public void InsertRight(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            tempNode.rchild = p.rchild;
            p.rchild = tempNode;
        }
        /// <summary>
        /// 删除指定节点的左子树
        /// </summary>
        /// <param name="p">指定的节点</param>
        /// <returns></returns>
        public Node<T> RemoveLeft(Node<T> p)
        {
            if (p == null || p.lchild == null)
            {
                return null;
            }
            Node<T> retuNode = p.lchild;
            p.lchild = null;
            return retuNode;
        }
        /// <summary>
        /// 删除指定节点的右子树
        /// </summary>
        /// <param name="p">指定的节点</param>
        /// <returns></returns>
        public Node<T> RemoveRight(Node<T> p)
        {
            if (p == null || p.rchild == null)
            {
                return null;
            }
            Node<T> retuNode = p.rchild;
            p.rchild = null;
            return retuNode;
        }
        public bool IsLeafNode(Node<T> p)
        {
            if (p == null)
            {
                return false;
            }
            return p.lchild == null && p.rchild == null;
        }
    }
}
