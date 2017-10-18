using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 17, 2, 7, 65, 71, 87, 49, 10 };
            Set first = new Set(array);
            int[] array1 = { 2, 7, 65, 71, 87 };
            Set second = new Set(array1);

            var nameList = new List<int>();//упорядочивание множества
            nameList.AddRange(array);
            Console.WriteLine("Неупорядоченное множество: ");
            foreach (var name in nameList)
                Console.Write("   {0}", name);

            Console.WriteLine();

            nameList.Sort();
            Console.WriteLine("Упорядоченное множество: ");
            foreach (var name in nameList)
                Console.Write("   {0}", name);

            Console.WriteLine();

            //Проверка на подмножество
            if (first > second)
            {
                Console.WriteLine("second является подмножеством first");
            }
            else
            {
                Console.WriteLine("second не является подмножеством first");
            }
            //Проверка на принадлежность
            Console.WriteLine("Введите значение элемента, который хотите удалить");
            int k = int.Parse(Console.ReadLine());
            if (k < first)
            {
                Console.WriteLine("Элемент удалён.");
            }
            else
            {
                Console.WriteLine("Элемент не принадлежит множеству.");
            }
            //Проверка на неравенство множеств
            if (first.Data.Length != second.Data.Length)
            {
                Console.WriteLine("second не равно first");
            }
            else
            {
                Console.WriteLine("second равно first");
            }

            //Проверка на пересечение
            if (first % second)
            {
                Console.WriteLine("Множества пересекаются.");
            }
            else
            {
                Console.WriteLine("Множества не пересекаются.");
            }
            
            Set.Owner owner = new Set.Owner(7, "Анна", "BSTU");
            Console.WriteLine($"\nВладелец:\nID: {owner.ID}\nимя: {owner.Name}\nорганизация: {owner.Organisation}\n");

            string s = "Найдём самое длинное слово";//поиск самого длинного слова
            var arr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x.Length).ToArray();
            Console.WriteLine("Самое длинное слово: {0} его длина = {1}",arr[3], arr[3].Length);
        }
    }
}

namespace ConsoleApp1
{
    class Set
    {
        private int[] data;

        public Set() { }

        public int[] Data
        {
            get
            {
                return data;
            }
        }
        public static bool operator >(int ignoreThis, Set ignoreThisToo) //Служебная функция
        {
            Console.WriteLine("Служебная функция");
            return false;
        }

        public static bool operator <(Set ignoreThis, Set ignoreThisToo) //Служебная функция
        {
            Console.WriteLine("Служебная функция");
            return false;
        }

        public Set(int[] data)
        {
            this.data = data;
        }

        public static bool operator <(int num, Set setToCheck) //Удаление элемента
        {
            for (int i = 0; i < setToCheck.data.Length; i++)
            {
                if (num == setToCheck.data[i])
                {
                    setToCheck.data[i] = setToCheck.data[i + 1];
                    return true;
                }
            }
            return false;
        }

        public static bool operator >(Set superSet, Set subSet) //Проверка на подмножество
        {
            bool result;

            for (int i = 0; i < subSet.data.Length; i++)
            {
                result = false;
                for (int a = 0; a < superSet.data.Length; a++)
                {
                    if (superSet.data[a] == subSet.data[i])
                    {
                        result = true;
                        break;
                    }
                }

                if (result == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator %(Set firstSet, Set secondSet) //Пересечение множеств
        {
            for (int i = 0; i < firstSet.data.Length; i++)
            {
                for (int a = 0; a < secondSet.data.Length; a++)
                {
                    if (secondSet.data[a] == firstSet.data[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public class Owner
        {
            private int id;
            private string name;
            private string organisation;

            public Owner(int id, string name, string organisation)
            {
                this.id = id;
                this.name = name;
                this.organisation = organisation;
            }

            public int ID
            {
                get
                {
                    return id;
                }
            }

            public string Name
            {
                get
                {
                    return name;
                }
            }
            public string Organisation
            {
                get
                {
                    return organisation;
                }
            }

            public class Date
            {
                private string dateOfCreation;

                public string DateOfCreation
                {
                    get
                    {
                        return dateOfCreation;
                    }
                }

                public Date(string dateOfCreation)
                {
                    this.dateOfCreation = dateOfCreation;
                }
            }
        }
    }
}