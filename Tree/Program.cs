using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//二叉树
namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTree<string> binaryTree = new MyBinaryTree<string>("A");//创建根节点
            binaryTree.InsertLeft(binaryTree.Root, "B");//根节点添加左
            binaryTree.InsertRight(binaryTree.Root, "C");//根节点添加右

            Node<string> nodeB = binaryTree.Root.lchild;//左子节点
            binaryTree.InsertLeft(nodeB, "D");//添加左

            Node<string> nodeC = binaryTree.Root.rchild;//右子节点
            binaryTree.InsertLeft(nodeC, "E");//添加左
            //binaryTree.InsertLeft(nodeC, "F");
            binaryTree.InsertRight(nodeC, "F");//添加右
            Console.WriteLine("递归遍历");
            Console.WriteLine("-----------前序遍历----------");
            binaryTree.PreOrder();//调用前序遍历扩展方法  根左右

            Console.WriteLine("\r\n-----------中序遍历----------");
            binaryTree.MidOrder();//调用中序遍历扩展方法  左根右

            Console.WriteLine("\r\n-----------后序遍历----------");
            binaryTree.PostOrder();//调用后序遍历扩展方法  左右根

            Console.Write("\r\n\r\n非递归遍历");

            Console.WriteLine("\r\n-----------前序遍历----------");
            binaryTree.PreOrderNoRecurise();//调用后序遍历扩展方法  左右根

            Console.WriteLine("\r\n-----------中序遍历----------");
            binaryTree.MidOrderNoRecurise();//调用后序遍历扩展方法  左右根

            Console.WriteLine("\r\n-----------后序遍历----------");
            binaryTree.PostOrderNoRecurise();//调用后序遍历扩展方法  左右根

            Console.WriteLine("\r\n-----------层次遍历----------");
            binaryTree.LevelOrder();

            Console.WriteLine("\r\n创建二叉查找树");

            MyBinarySearchTree myBinarySearch = new MyBinarySearchTree();
            myBinarySearch.InsertNode(8);
           
                myBinarySearch.InsertNode(4);
            myBinarySearch.InsertNode(10);
            myBinarySearch.InsertNode(20);
            myBinarySearch.InsertNode(2);
            myBinarySearch.InsertNode(5);
            myBinarySearch.InsertNode(1);
            myBinarySearch.InsertNode(15);
            myBinarySearch.InsertNode(21);
            Console.WriteLine("\r\n-----------中序遍历----------");
            myBinarySearch.MidPrint();

            Console.WriteLine("\r\n-----------层次遍历----------");
            myBinarySearch.LevelOrder();

            Console.WriteLine("\r\n-----------四则运算----------");
            Console.Write("请输入四则运算表达式:");
           string construcStr = Console.ReadLine();
            MyBinaryExprTree exprTree = new MyBinaryExprTree(construcStr);
           Console.WriteLine( "结果：{0}={1}",construcStr, exprTree.GetResult());
            Console.ReadKey();
        }
    }

}
