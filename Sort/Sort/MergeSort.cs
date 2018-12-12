using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class MergeSort
    {
        public delegate int[] PrintDel(int[] arr, bool a);//声明输出数组内容委托
        private PrintDel _printDel;//创建委托对象
        public MergeSort(PrintDel printDel)
        {
            _printDel = printDel;
        }
        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="arr">要排序的数组</param>
        public void mergeSort(int[] arr)
        {
            Console.WriteLine("\r\n归并排序：");
           arr= _printDel(arr, true);
            int l = 0, r = arr.Length - 1;//起点和终点
            mergeSort(arr, l, r);
            _printDel(arr, false);
        }
        /// <summary>
        /// 归并排序，将数组分组
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="L">左边界</param>
        /// <param name="R">右边界</param>
        public void mergeSort(int[] arr, int L, int R)
        {
            if (L < R)//左边界应始终小于右边界
            {
                int M = (L + R) / 2;//取中间值
                mergeSort(arr, L, M);//左边的集合，L -M
                mergeSort(arr, M + 1, R);//右边的集合，M+1 -R
                merge(arr, L, M, R);//对所有两边的集合进行排序
            }
        }
        /// <summary>
        /// 归并排序，将分组的数组排序
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="L">左边界</param>
        /// <param name="M">中间</param>
        /// <param name="R">右边界</param>
        private void merge(int[] arr, int L, int M, int R)
        {
            int[] t = new int [R - L + 1];//临时数组，临时存放数据
            int left = L, right = M + 1;//左右两个集合的起始位置
            int temp = 0;//临时数组的起始位置

            while (left <= M && right <= R)//M为左边集合下标的最大值，R为右边集合下标的最大值
            {
                //比较两个集合，将较小的值放到临时数组中，直至左右两个集合某个集合的值全部取出
                if (arr[left] > arr[right]) t[temp++] = arr[right++];
                else t[temp++] = arr[left++];

            }
            //检查左右两边的某个集合是否还有值，若有值则赋值给临时集合
            while (left <= M) { t[temp++] = arr[left++]; }
            while (right <= R) { t[temp++] = arr[right++]; }
            for (int i = 0; i <= R - L; i++)
                arr[i + L] = t[i];//将临时集合中的值赋值给原数组

        }
    }
}
