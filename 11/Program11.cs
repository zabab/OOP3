using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class SamplesArrayList
{
    class User
    {
        public static Dictionary<double, double> MyDict(int i)
        {
            Dictionary<double, double> dict = new Dictionary<double, double>
            {
                [0] = 1.1,
                [1] = 2.2,
                [2] = 3.3,
                [3] = 4.4,
                [4] = 5.5
            };
            return dict;
        }
    }
    public static void Show(IEnumerable myList)
    {
        foreach (Object obj in myList)
            Console.WriteLine("{0}", obj);
    }
    public static void Del(IEnumerable myList, object k)
    {
        ArrayList myAL1 = new ArrayList();
        foreach (Object obj in myList)
            if (obj == k) { }
            else
            {
                myAL1.Add(obj);
            }
        int i = 0;
        foreach (Object obj in myAL1)
        {
            Console.WriteLine(" {0}", obj);
            i++;
        }
        Console.WriteLine("Количество элементов в массиве: {0}", i+1);
    }
    private static void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
    }
    public static void Main()
    {
        //необобщенная коллекция
        ArrayList myAL = new ArrayList();
        myAL.Add(1);
        myAL.Add(2);
        myAL.Add(3);
        myAL.Add(4);
        myAL.Add(5);
        myAL.Add("World");
        int k;
        Console.WriteLine("Введите индекс элемента, который надо удалить");
        k = int.Parse(Console.ReadLine());
        Del(myAL, myAL[k]);
        //обобщенная коллекция
        Dictionary<double, double> numbers = User.MyDict(5);

        numbers.Add(5, 6.6);
        Show(numbers);
        ICollection<double> keys = numbers.Keys;
        ICollection<double> values = numbers.Values;
        //из Dictionary в Queue
        Queue<double> queue = new Queue<double>();
        foreach (double j in values)
            queue.Enqueue(j);
        //наблюдаемая коллекция
        var data = new ObservableCollection<string>();
        data.CollectionChanged += Data_CollectionChanged;
        data.Add("qwer");
        data.Add("asdf");
        data.Insert(1, "nbvcx");
        data.Remove("asdf");
        foreach (var t in data)
        Console.WriteLine(" {0}", t);
    }
}