using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class SelectTypeSort
    {
        public delegate void PrintDel(int[] arr, bool a);//声明输出数组内容委托
        private PrintDel _printDel;//创建委托对象
        public SelectTypeSort(PrintDel printDel)
        {
            _printDel = printDel;
        }
        public void selectionSort(int[] arr)//小数往前放
        {
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)//控制比较的值
            {
                for (int j = i + 1; j < len; j++)//和那个数进行比较
                {
                    if (arr[i] > arr[j])
                    {//若前面的数大于后面的数则交换，使小数往前放
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            _printDel(arr, false);
        }
        //建立大根堆
        private void buildMaxHeap(int[] arr, int index, int len)
        {

            int child;
            for (; 2 * index + 1 < len;   index=child)//每次循环更新index的值，保证小数放在叶子上
            {
                //对于index节点，左子树2*index+1 右子树2*index+2
                child = 2 * index + 1;//获取左子树
                if (child < len - 1 && arr[child + 1] > arr[child])//child<len-1判断是否有右子树，arr[child + 1] > arr[child]判断右子树是否大于左子树
                    child++;//若大于，则用右子树与根节点比较
                //使用两个子树中最大的子树与根节点比较
                if (arr[child] > arr[index])//若子树比根节点大，则交换
                {
                    int temp = arr[child];
                    arr[child] = arr[index];
                    arr[index] = temp;
                }
                else break;
            }
        }
        //堆排序
        public void HeapSort(int [] arr)
        {
            int len = arr.Length;//数组长度
            for (int i = len/2-1; i >=0; i--)//第一次建大根堆
            {
                buildMaxHeap(arr, i, len);
            }
            for (int i = len-1; i >0 ; i--)
            {
                int temp = arr[i];
                arr[i] = arr[0];
                arr[0] = temp;//将大根堆的值与最后一个值替换
                buildMaxHeap(arr, 0, i);//长度减1，最大值在后面固定，将前面的值继续排成大根堆，如此循环直至长度为1
            }
            _printDel(arr, false);
        }
    }
}
