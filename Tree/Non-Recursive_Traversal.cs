using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    static class Non_Recursive_Traversal
    {
        /// <summary>
        /// 非递归前序遍历   根左右
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myBinary"></param>
        public static void PreOrderNoRecurise<T>(this MyBinaryTree<T> myBinary)
        {
            if (myBinary.Root == null) return;//检查根节点
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(myBinary.Root);//根节点入栈
            Node<T> tempnode = null;
            while (stack.Count > 0)
            {
                tempnode = stack.Pop();
                Console.Write("{0} ", tempnode.data);
                if (tempnode.rchild != null)//检查右子树
                    stack.Push(tempnode.rchild);//出栈的顺序为先进后出，为了输出为根=>左=>右，这里先让右子树进栈，
                if (tempnode.lchild != null)//再让左子树进栈,使得循环时保证了左子树先出栈
                    stack.Push(tempnode.lchild);
            }
        }
        /// <summary>
        /// 非递归中序遍历   左根右
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myBinary"></param>
        public static void MidOrderNoRecurise<T>(this MyBinaryTree<T> myBinary)
        {
            if (myBinary.Root == null) return;//检查根节点
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> tempnode = myBinary.Root;

            while (tempnode != null || stack.Count > 0)
            {

                while (tempnode != null)//将所有左子树遍历入栈
                {
                    stack.Push(tempnode);
                    tempnode = tempnode.lchild;
                }
                tempnode = stack.Pop();
                Console.Write("{0} ", tempnode.data);

                tempnode = tempnode.rchild;//循环右子树
            }
        }
        /// <summary>
        /// 非递归后序遍历
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myBinary"></param>
        public static void PostOrderNoRecurise<T>(this MyBinaryTree<T> myBinary)
        {
            if (myBinary.Root == null) return;//检查根节点
            Stack<Node<T>> stackIn = new Stack<Node<T>>();//暂时存储的栈 
            Stack<Node<T>> stackOut = new Stack<Node<T>>();//向外输出的栈 栈内节点顺序 根=》右=》左
            stackIn.Push(myBinary.Root);

            Node<T> currentNode = null;

            while (stackIn.Count > 0)
            {
                currentNode = stackIn.Pop();
                stackOut.Push(currentNode);

                if (currentNode.lchild != null)//输出左右根，故在stackOut栈中的顺序为根右左
                    stackIn.Push(currentNode.lchild);//为保证向stackOut压入根左右
                if (currentNode.rchild != null) //先将左子树压入stackIn，在压入右子树，
                    stackIn.Push(currentNode.rchild);//使得stackIn栈弹出时先弹出右子树,在弹出左子树 

            }
            while (stackOut.Count > 0)//出栈
                Console.Write("{0} ", stackOut.Pop().data);
        }
        /// <summary>
        /// 层次遍历
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myBinary"></param>
        public static void LevelOrder<T>(this MyBinaryTree<T> myBinary)
        {
            if (myBinary.Root == null) return;
            Queue<Node<T>> queueNodes = new Queue<Node<T>>();//队列 先进先出
            queueNodes.Enqueue(myBinary.Root);//根节点
            Node<T> tempNode = null;
            while (queueNodes.Count > 0)
            {
                tempNode = queueNodes.Dequeue();//出队
                Console.Write("{0} ", tempNode.data);

                if (tempNode.lchild != null)//使用队列，依次入队
                    queueNodes.Enqueue(tempNode.lchild);
                if (tempNode.rchild != null)
                    queueNodes.Enqueue(tempNode.rchild);
            }
        }
    }
}
