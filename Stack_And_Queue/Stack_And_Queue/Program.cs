using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    //基于数组的栈
    public class MyArrayStack<T>
    {
        private T[] nodes;
        private int index;

        public MyArrayStack(int capacity)
        {
            nodes = new T[capacity];
            index = 0;
        }
        public void Push(T node)
        {
            if (index==nodes.Length)
            {

            }
            nodes[index] = node;
            index++;
        }
        public T Pop()
        {
            if (index == 0)
                return default(T);
            T node = nodes[index - 1];
            index--;
            nodes[index] = default(T);
            if (index > 0 && index == nodes.Length / 4)
            {

            }
            return node;
        }
        private void ResizeCapacity(int newCapacity)
        {
            T[] newnodes = new T[newCapacity];
            if (newCapacity > nodes.Length)      
                newCapacity = nodes.Length;      
            
            for (int i = 0; i < newCapacity; i++)   
                    newnodes[i] = nodes[i];

            nodes = newnodes;
        }
        public bool IsEmpty()
        {
            return this.index == 0;
        }
        public int Size
        {
            get
            {
                return this.index;
            }
        }
    }
}
