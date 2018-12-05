using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//树的递归遍历
namespace Tree
{
    static public class Recursive_Traversal
    {
        /// <summary>
        /// 前序遍历扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myBinaryTree"></param>
        public static void PreOrder<T>(this MyBinaryTree<T> myBinaryTree)
        {
            PreOrder(myBinaryTree.Root);
        }
        /// <summary>
        /// 前序遍历   根左右
        /// </summary>
        /// <param name="node"></param>
        private static void PreOrder<T>(Node<T> node)
        {
            if (node != null)
            {
                Console.Write("{0} ", node.data);
                PreOrder(node.lchild);
                PreOrder(node.rchild);
            }
        }
        /// <summary>
        /// 中序遍历 MidOrder扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myBinaryTree"></param>
        public static void MidOrder<T>(this MyBinaryTree<T> myBinaryTree)
        {
            MidOrder(myBinaryTree.Root);
        }
        /// <summary>
        /// 中序遍历   左根右
        /// </summary>
        /// <param name="node"></param>
        private static void MidOrder<T>(Node<T> node)
        {
            if (node != null)
            {
                MidOrder(node.lchild);
                Console.Write("{0} ", node.data);
                MidOrder(node.rchild);
            }
        }
        public static void PostOrder<T>(this MyBinaryTree<T> myBinaryTree)
        {
            PostOrder(myBinaryTree.Root);
        }
        ///// <summary>
        ///// 后序遍历   左右根
        ///// </summary>
        ///// <param name="node"></param>
        private static void PostOrder<T>(Node<T> node)
        {
            if (node != null)
            {
                PostOrder(node.lchild);
                PostOrder(node.rchild);
                Console.Write("{0} ", node.data);
            }
        }


    }
}
