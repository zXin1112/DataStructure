using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] arr = new int[] { 10, 2, 9, 5, 6, 11, 8, 12, 1, 100, -1, -55, 45, 32 };
            //插入类排序
            SortInsertionTypes insertionTypes = new SortInsertionTypes(printDelFn);
            insertionTypes.insertionSort(arr);
            arr = GetDisruptedItems(arr);
            insertionTypes.shellSort(arr);
            //交换类排序
            SortExchangeTypes sortExchangeTypes = new SortExchangeTypes(printDelFn);
            arr = GetDisruptedItems(arr);
            sortExchangeTypes.BubleSort(arr);
            arr = GetDisruptedItems(arr);
            sortExchangeTypes.QuickSort(arr);
            //选择类排序
            SelectTypeSort selectTypeSort = new SelectTypeSort(printDelFn);
            arr = GetDisruptedItems(arr);
            selectTypeSort.selectionSort(arr);
            arr = GetDisruptedItems(arr);
            selectTypeSort.HeapSort(arr);
            //归并排序
            MergeSort mergeSort = new MergeSort(printDelFn);
            arr = GetDisruptedItems(arr);
            mergeSort.mergeSort(arr);
            Console.ReadKey();
        }
        public static int[] printDelFn(int[] _arr, bool a)
        {
            if (a) Console.Write("排序前："); else Console.Write("排序后：");
            for (int i = 0; i < _arr.Length; i++)
            {
                Console.Write("{0} ", _arr[i]);
            }
            if (a) return GetDisruptedItems(_arr);
            else return null;
        }
        public static int[] GetDisruptedItems(int[] item)
        {
            //生成一个新数组：用于在之上计算和返回
            int[] temp;
            temp = new int[item.Length];
            for (int i = 0; i < temp.Length; i++) { temp[i] = item[i]; }
            //打乱数组中元素顺序
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < temp.Length; i++)
            {
                int x, y; int t;
                x = rand.Next(0, temp.Length);
                do
                {
                    y = rand.Next(0, temp.Length);
                } while (y == x);
                t = temp[x];
                temp[x] = temp[y];
                temp[y] = t;
            }
            return temp;
        }
    }
}
