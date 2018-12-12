using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class SortInsertionTypes
    {
        public delegate int[] PrintDel(int[] arr, bool a);
        public PrintDel _printDel;
        public SortInsertionTypes(PrintDel printDel)
        {
            _printDel = printDel;
        }
        //插入排序
        public void insertionSort( int[] arr)
        {
            Console.WriteLine("插入类排序之插入排序：");

            arr=_printDel(arr, true);
            var len = arr.Length;
            //int preIndex, current;//前一个元素和当前元素
            //for (var i = 1; i < len; i++)//默认第一个元素已排好，从第二个元素开始
            //{
            //    preIndex = i - 1;//第一个比较值的索引
            //    current = arr[i];//要比较的值
            //    while (preIndex >= 0 && arr[preIndex] > current)//当索引在数组中且值大于要比较的值（current）时
            //    {
            //        arr[preIndex + 1] = arr[preIndex];//移动元素
            //        preIndex--;//指针移动到下一个要比较的值
            //    }//为新值的插入空出位置
            //    arr[preIndex + 1] = current;//找到合适的位置，插入
            //}
            ////此排序方法，比较循序为从排好顺序的数组中从后往前排序
            //_printDel(arr, false);
            int tmp;
            for (int i = 1; i < len; i++)
            {
                tmp = arr[i];//取一个值
                int j;
                for (j=i;j>0&&arr[j-1]>tmp;j--)//和前一个值比较，若前一个值大于当前的值
                    arr[j] = arr[j- 1];//将前一个值移动到当前值的位置,j-- j移动到j-1的位置指针指向前一个位置
                arr[j] = tmp;//当不满足条件后，插入
                
            }
            _printDel(arr, false);
        }
        //希尔排序
        public void shellSort(int[] arr)
        {
            Console.WriteLine("\r\n插入类排序之希尔排序：");
            arr= _printDel(arr, true);
            int len = arr.Length;
            int temp,gap=1;
            while (gap < len / 3) gap = gap * 3 + 1;//间隔初值

            for (; gap > 0; gap /= 3)//间隔变换
            {
                //插入排序
                for(int i = gap; i < len; i++)
                {
                    temp = arr[i];//指定间隔取值
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        //当前值比前面指定间隔的值小时，下一个值还是指定间隔的值
                        arr[j] = arr[j - gap];//移动位置到当前值，为当前值让位
                    arr[j] = temp;//当前值 移动到 前面 指定间隔的值
                }
            }
          
            _printDel(arr, false);
        }
    }
}
