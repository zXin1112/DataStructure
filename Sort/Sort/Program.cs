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
            int[] arr = new int[] { 10, 2, 9, 5, 6, 11, 8, 12, 1,100,-1,-55,45,32 };
            ////插入类排序
            //SortInsertionTypes insertionTypes = new SortInsertionTypes(printDelFn);
            //insertionTypes.insertionSort(arr);
            //insertionTypes.shellSort(arr);
            ////交换类排序
            //SortExchangeTypes sortExchangeTypes = new SortExchangeTypes(printDelFn);
            //sortExchangeTypes.BubleSort(arr);
            //sortExchangeTypes.QuickSort(arr);
            SelectTypeSort selectTypeSort = new SelectTypeSort(printDelFn);
            selectTypeSort.selectionSort(arr);
            selectTypeSort.HeapSort(arr);
            Console.ReadKey();
        }
        public static void printDelFn(int[] _arr, bool a)
        {
            if (a) Console.Write("排序前："); else Console.Write("排序后：");
            for (int i = 0; i < _arr.Length; i++)
            {
                Console.Write("{0} ", _arr[i]);
            }
        }

    }
}
