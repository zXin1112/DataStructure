using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class SortExchangeTypes
    {

        public delegate void PrintDel(int[] arr, bool a);//声明输出数组内容委托
        private PrintDel _printDel;//创建委托对象
        public SortExchangeTypes(PrintDel printDel)
        {
            _printDel = printDel;
        }
        public void BubleSort(int[] arr)//大数往后放
        {
            Console.WriteLine("\r\n交换类排序之冒泡排序：");
            _printDel(arr, true);

            int length = arr.Length;
            for (int i = 1; i < length; i++)//外层循环 控制循环多少次
                for (int j = 0; j < length - i; j++)//内层循环 控制每次比较的两个元素
                    if (arr[j] >arr[j + 1])//若前面的数大于后面的数，则交换，使大数往后放
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
            _printDel(arr, false);
        }
        public void QuickSort(int[] arr)
        {
            Console.WriteLine("\r\n交换类排序之快速排序：");
            _printDel(arr, true);
            QuickSort(arr, 0, arr.Length - 1);
            _printDel(arr, false);
        }
        private void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return;//如果左边的游标大于右边的则返回
            int i = left, j = right, key = arr[i];//左边的起点，右边的起点，比较的值key一般取第一个值
            while (i < j)//左边的游标小于右边的时循环执行
            {
                while (i < j && arr[j] >= key) j--;//如果右边的值大于key则往前移动
                if (i < j) { int temp = arr[j]; arr[j] = arr[i]; arr[i] = temp; }//否则交换
                while (i < j && arr[i] <= key) i++;//如果左边的值小于key则往后移动
                if (i < j) { int temp = arr[i]; arr[i] = arr[j]; arr[j] = temp; }//否则交换               
            }
            //左边排序
            QuickSort(arr, left, i - 1);
            //右边排序
            QuickSort(arr, i + 1, right);

        }
    }
}
