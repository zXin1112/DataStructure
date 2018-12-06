using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class MyBinarySearchTree
    {

        private Node<int> root;

        public Node<int> Root { get => root; }//根节点

        public MyBinarySearchTree() { }
        public MyBinarySearchTree(int data) { root = new Node<int>(data); }
        /// <summary>
        /// 构建二叉查找树
        /// </summary>
        /// <param name=""></param>
        public void InsertNode(int data)
        {
            Node<int> newnode = new Node<int>(data);
          

            if (root == null) root = newnode;
            else
            {
                Node<int> currentNode = root;
                Node<int> parentNode = null;
                while (currentNode != null)
                {
                    parentNode = currentNode;
                    if (currentNode.data < data) currentNode = currentNode.rchild;//新节点比当前节点大时，往右子树找下一个节点
                    else currentNode = currentNode.lchild;//否则去左子树
                }
                //循环执行完毕后，找到了叶子结点
                if (parentNode.data < data) parentNode.rchild = newnode;//新节点大于叶子结点时，新节点作为叶子结点的右子树
                else parentNode.lchild = newnode;//新节点小于叶子结点时，新节点作为叶子结点的左子树
            }
        }
        //中序遍历
        public void MidPrint()
        {
            if (root == null) return;
            Stack<Node<int>> stack = new Stack<Node<int>>();
            Node<int> tempNode = root;
            while (tempNode!=null || stack.Count > 0)
            {
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.lchild;
                }
                tempNode = stack.Pop();
                Console.Write("{0} ", tempNode.data);
                tempNode = tempNode.rchild;
            }
        }
        //层次遍历
        public void LevelOrder()
        {
            if (root == null) return;
            Queue<Node<int>> nodes = new Queue<Node<int>>();
            nodes.Enqueue(root);
            Node<int> tempNode = null;
            while (nodes.Count > 0)
            {
                tempNode = nodes.Dequeue();
                Console.Write("{0} ", tempNode.data);

                if (tempNode.lchild != null) nodes.Enqueue(tempNode.lchild);
                if (tempNode.rchild != null) nodes.Enqueue(tempNode.rchild);

            }
        }
    }
}
