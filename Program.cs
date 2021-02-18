using System;

namespace ConsoleApp1
{
    public interface IListDS<T>
    {
        int GetLength();
        void Clear();
        bool IsEmpty();
        bool IsFull();
        void Append(T item);
        void Insert(T item, int index);
        T Delete(int i);
        T GetElem(int i);
        int Locate(T value);
    }
    public class SeqList<T> : IListDS<T>
    {
        private int maxsize;
        private T[] data;
        private int last;

        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public int Last
        {
            get
            {
                return last;
            }
        }

        public int Maxsize
        {
            get
            {
                return maxsize;
            }
        }
        public SeqList(int size)
        {
            data = new T[size];
            maxsize = size;
            last = -1;
        }

        public int GetLength()
        {
            return last + 1;
        }
        public void Clear()
        {
            last = -1;
        }
        public void Append(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("LIST IS FULL");
                return;
            }
            data[++last] = item;
        }
        public T Delete(int i)
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("LIST IS EMPTY");
                return tmp;
            }
            if (i <1 || i>last +1)
            {
                Console.WriteLine("INDEX IS ERROE");
                return tmp;
            }
            if(i == last + 1)
            {
                tmp = data[last--];
            }
            else
            {
                tmp = data[i - 1];
                for (int j = 1; j <= last; j++)
                {
                    data[j] = data[j + 1];
                }
            }
            --last;
            return tmp;
        }

        public T GetElem(int i)
        {
            if (IsEmpty()|| (i<1)||(i>last+1))
            {
                Console.WriteLine("LIST IS EMPTY or INDEX IS ERROR");
                return default(T);
            }
            return data[i - 1];
        }

        public void Insert(T item, int index)
        {
            if (IsFull())
            {
                Console.WriteLine("LIST IS FULL");
                return;
            }
            if(index < 1 || index > last + 2)
            {
                Console.WriteLine("INDEX IS ERROE");
                return;
            }
            if(index == last + 2)
            {
                data[last + 1] = item;
            }
            else
            {
                for (int i = last; i >= index -1; --i)
                {
                    data[i + 1] = data[i];
                }
                data[index - 1] = item;
            }
            ++last;
        }

        public bool IsEmpty()
        {
            if (last == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsFull()
        {
            if (last == maxsize-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Locate(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("LIST IS EMPTY");
                return -1;
            }
            int i = 0;
            for (i = 0; i <= last; ++ i)
            {
                if (value.Equals(data[i]))
                {
                    break;
                }
            }
            if (i>last)
            {
                return -1;
            }
            return i;
        }

      
    }
    class Program
    {
        static void Main(string[] args)
        {
            SeqList<int> IntList = new SeqList<int>(5);
            IntList.Delete(1);
            Console.WriteLine("Hello World!");

        }
    }
}
