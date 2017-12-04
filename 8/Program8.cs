using System;
using System.Collections;
using System.IO;
using System.Text;

namespace ConsoleApplication1
{
    // Объявляем обобщенный интерфейс
    public interface IInterface<T>
    where T : struct
    {
        void Add(T[] a,T k);
        void Del(T[] a,int q);
        void Read();
        void Exception(T[] a, int q,int l);
        void SaveFile(T[] a);
    }

    // Реализуем интерфейс в классе MyObj
    class MyObj<T> : IInterface<T> where T : struct
    {
        public int i = 0;
        public int longOb { get; set; }
        T[] myarr;

        public MyObj(int i)
        {
            longOb = i;
        }

        public MyObj(int i, T[] arr)
        {
            longOb = i;
            myarr = new T[i];
            for (int j = 0; j < arr.Length; j++)
                myarr[j] = arr[j];
        }

        public MyObj()
        {}

        public void Add(T[] a,T k)
        {
            a[i] = k;
            i++;
        }

        public void Del(T[] a,int q)
        {
            for(int e=0;e<i;e++)
            {
                if (e == q)
                    for (int r = e; r < i; r++)
                    {
                        a[r] = a[r + 1];
                    }
            }
        }
        public void Read() { }
        public void Exception(T[] x, int y,int l)
        {

            if (x.Length < y || x.Length <= 0 || y>l)
            {
                Exception a = new Exception();
                Console.WriteLine("В массиве содержится только {0} элементa/-ов",l);
                throw a;
            }
        }
        public void SaveFile(T[] a)
        {
            StreamWriter textFile = new StreamWriter(@"test.txt");
            for (int i = 0; i < a.Length; i++)
            {
                textFile.WriteLine(a[i]);
            }
            textFile.Close();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Сколько элементов хотите добавить в массив MyArrInt?");
            int t1 = int.Parse(Console.ReadLine());
            int[] MyArrInt = new int[t1];
            MyObj<int> IntConst = new MyObj<int>(MyArrInt.Length, MyArrInt);
            for (int y = 0; y < t1; y++)
            {
                Console.WriteLine("MyArrInt[{0}]: ",y);
                var k = int.Parse(Console.ReadLine());
                IntConst.Add(MyArrInt, k);
            }
            Console.WriteLine("Ваш массив: ");
            for(int y=0;y<t1;y++)
            {
                Console.WriteLine("MyArrInt[{0}]={1}",y,MyArrInt[y]);
            }
            Console.WriteLine("Введите индекс элемента, который хотите удалить: ");
            int q = int.Parse(Console.ReadLine());
            try {
                IntConst.Exception(MyArrInt, q,t1);
                IntConst.Del(MyArrInt, q);
                Console.WriteLine("Указанный элемент удалён. Теперь ваш массив: ");
                for (int y = 0; y < t1 - 1; y++)
                {
                    Console.WriteLine("MyArrInt[{0}]={1}", y, MyArrInt[y]);
                }
            }
            catch (FormatException ex)
            {
                Console.Write(ex.Message + "\n");
                Console.Write(ex.TargetSite + "\n");
                if (ex.Data != null)
                {
                    foreach (DictionaryEntry d in ex.Data)
                        Console.WriteLine(d.Value);
                }
            }
            catch { }
            finally { }
            IntConst.SaveFile(MyArrInt);
            //работа с double
            Console.WriteLine("Сколько элементов хотите добавить в массив MyArrDouble?");
            int t = int.Parse(Console.ReadLine());
            double[] MyArrDouble = new double[t];
            MyObj<double> DoubleConst = new MyObj<double>(MyArrDouble.Length, MyArrDouble);
            for (int y = 0; y < t; y++)
            {
                Console.WriteLine("MyArrDouble[{0}]: ", y);
                var k = double.Parse(Console.ReadLine());
                DoubleConst.Add(MyArrDouble, k);
            }
            Console.WriteLine("Ваш массив: ");
            for (int y = 0; y < t; y++)
            {
                Console.WriteLine("MyArrDouble[{0}]={1}", y, MyArrDouble[y]);
            }
            Console.WriteLine("Введите индекс элемента, который хотите удалить: ");
            int q1 = int.Parse(Console.ReadLine());
            try
            {
                DoubleConst.Exception(MyArrDouble, q1, t);
                DoubleConst.Del(MyArrDouble, q1);
                Console.WriteLine("Указанный элемент удалён. Теперь ваш массив: ");
                for (int y = 0; y < t - 1; y++)
                {
                    Console.WriteLine("MyArrDouble[{0}]={1}", y, MyArrDouble[y]);
                }
            }
            catch (FormatException ex)
            {
                Console.Write(ex.Message + "\n");
                Console.Write(ex.TargetSite + "\n");
                if (ex.Data != null)
                {
                    foreach (DictionaryEntry d in ex.Data)
                        Console.WriteLine(d.Value);
                }
            }
            catch { }
            finally { }
        }
    }
}