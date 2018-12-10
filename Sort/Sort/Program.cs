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
            int[] arr = new int[] { 10, 2, 9, 5, 6, 11, 8, 12, 1 };
            SortInsertionTypes insertionTypes = new SortInsertionTypes(printDelFn);
          // insertionTypes.insertionSort(arr);
            insertionTypes.shellSort(arr);
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
