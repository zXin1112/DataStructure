using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//动态顺序列表之ArrayList 与List<T>
namespace ArrayListAndList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArrayList:");
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                arrayList.Add(i);//添加数据，对数组进行容量判断
            }
            arrayList.RemoveAt(2);//移除数据，会进行元素移动操作
            foreach (var item in arrayList)
            {
                Console.Write("{0} ",item);
            }

            Console.WriteLine("\r\nList<T>:");
            List<int> intList = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                intList.Add(i);//添加数据
            }
            int number1 = intList[1];
            int number2 = intList[2];
            foreach (var item in intList)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine("\r\nList<T>由于使用泛型，省去了大量的装箱拆箱操作");
            Console.ReadKey();
        }
    }
}
