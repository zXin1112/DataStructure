using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//顺序表之数组
namespace Sequence_List_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //数组是线性表的顺序存储结构在程序语言中最直接的表现形式。
            int[] arrInt = new int[5];
            arrInt[3] = 5;
            arrInt[2] = 3;//数组为值类型
            DataRow[] dataRows = new DataRow[5];
           // dataRows[2] = new DataTable().Rows[0];
           // dataRows[3] = new DataTable().NewRow();//引用类型
        }
    }
}
