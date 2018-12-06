using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//四则运算
namespace Tree
{
    public class MyBinaryExprTree
    {
        private Node _head;//头指针
        private string _expression;//构建二叉树的字符串
        private int _pos;//解析字符串的位置

        public MyBinaryExprTree(string construcStr)//构造函数
        {
            _expression = construcStr;//获取运算式
            _head = CreateTree();//根据运算式创建表达式树
        }
        //创建表达式树
        private Node CreateTree()
        {
            Node head = null;//头结点
            while (_pos < _expression.Length)//一个字符一个字符的解析
            {
                Node node = GetNode();//为其中一个字符创建节点
                if (head == null)//若头部为空，则使其为根节点
                {
                    head = node;
                }
                else if(!head.IsOptr)//根节点为数字，当前节点为根，原根节点变左孩子
                {
                    node.Left = head;
                    head = node;
                }
                else if(!node.IsOptr)//当前节点为数字,沿右路径插入最右边
                {
                    Node tempNode = head;
                    while (tempNode.Right != null)
                        tempNode = tempNode.Right;
                    tempNode.Right = node;
                }
                else//节点是运算符
                {
                    if (GetPriority((char)node.Data) <= GetPriority((char)head.Data)) // 优先级低则成为根，原二叉树成为插入节点的左子树
                    {
                        node.Left = head;
                        head = node;
                    }
                    else // 优先级高则成为根节点的右子树，原右子树成为插入节点的左子树
                    {
                        node.Left = head.Right;
                        head.Right = node;
                    }
                }
            }
            return head;
        }
        //获取字符优先级
        private int GetPriority(char optr)
        {
            if (optr == '+' || optr == '-')
            {
                return 1;
            }
            else if (optr == '*' || optr == '/')
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        //为字符创建节点
        private Node GetNode()
        {
            char ch = _expression[_pos];//获取其中一个节点
            if (char.IsDigit(ch))//判断其是否为数字
            {
                StringBuilder sbNumber = new StringBuilder();
                while (_pos < _expression.Length && char.IsDigit(ch = _expression[_pos]))//当数字为一位以上，获取数字，例1只循环一次获取数字1。22循环两次，获取数字22
                {
                    sbNumber.Append(ch);
                    _pos++;
                }
                return new Node(Convert.ToInt32(sbNumber.ToString()));//创建节点
            }
            else//操作符
            {
                _pos++;
                return new Node(ch);//创建节点
            }
        }
        // 先序遍历进行表达式求值
        private int PreOrderCalc(Node node)
        {
            int num1, num2;
            if (node.IsOptr)//若节点为字符
            {
                // 递归先序遍历计算num1
                num1 = PreOrderCalc(node.Left);
                // 递归先序遍历计算num2
                num2 = PreOrderCalc(node.Right);
                char optr = (char)node.Data;

                switch (optr)
                {
                    case '+':
                        node.Data = num1 + num2;
                        break;
                    case '-':
                        node.Data = num1 - num2;
                        break;
                    case '*':
                        node.Data = num1 * num2;
                        break;
                    case '/':
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException("除数不能为0！");
                        }
                        node.Data = num1 / num2;
                        break;
                }
            }

            return node.Data;
        }
        public int GetResult()
        {
            return PreOrderCalc(_head);
        }
    }
}
