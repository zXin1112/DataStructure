using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Linear_List
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("线性表：顺序存储结构和链式存储结构\r\n");
            builder.Append("顺序存储结构是指用一块地址连续的存储空间依次存储线性表中的数据元素\r\n");
            builder.Append("链式存储结构 单链表、静态链表、循环链表和双向链表");
            Console.WriteLine(builder.ToString());
            Console.ReadKey();
        }
    }
}
