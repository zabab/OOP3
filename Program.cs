using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OOP3
{
    class Program
    {
        //Первая часть
        public partial class SuperString
        {
            public string str;
            readonly private int number;
            private static int count;
            private int hex;
            private const string type = "SyperString";


            public string Str
            {
                get
                {
                    return str;
                }
                set
                {
                    str = value;
                }
            }

            public int Count
            {
                get
                {
                    return count;
                }
            }


            public int Number
            {
                get
                {
                    return number;
                }
                set
                {
                    Console.WriteLine("\nОшибка доступа!");
                }
            }
            public int Hex
            {
                get
                {
                    if (hex == 0)
                    {
                        return GetHashCode();
                    }
                    else
                    {
                        return hex;
                    }
                }
            }
           



            //Статический конструктор 
            static SuperString()
            {
                count = 0;
            }
            
            //Стандартный конструктор   
            public SuperString()
            {
                str = "NoFind!";
                this.number = ++count;
            }
            //Конструктор с 1 аргументом
            public SuperString(string ArgStr) : this()
            {
                str = ArgStr;
              
            }

            //Конструктор с параметром по умолчению
            public SuperString(int Integer = 0) : this()
            {
                str = System.Convert.ToString(Integer);
            }
            //Приватный конструктор
            private SuperString(string ArgStr, int Integer) : this()
            {
                str = ArgStr + System.Convert.ToString(Integer);
            }

            //Иницализатор
            SuperString privateSuperString(string ArgStr, int Integer)
            {
                SuperString New = new SuperString(ArgStr, Integer);
                return New;
            }
        }


        //Вторая часть
        public partial class SuperString
        {

            //Копирование в строку значение ArgStr
            public void Copy(string ArgStr)
        {
            this.str = ArgStr;
            }
            //Копирование в CуперСтроку значение ArgStr
            public void Copy(SuperString ArgStr)
            {
                this.str = ArgStr.str;
            }


            //Копирование из СуперСтроку значение в строку ArgStr
            public void CopyIn(ref string ArgStr)
            {
             ArgStr = this.str;
            }
            //Копирование из СуперСтроку значение в Суперстроку ArgStr
            public void CopyIn(ref SuperString ArgStr)
            {
                ArgStr.str = this.str;
            }

         //Выведение информации(Переопределение метода)
        public override string ToString()
        {
                return "[" + number + "/" + count + "]" + " " + type + ": " + str + " \n H: " + GetHashCode() + "\n";
        }

            // переопределение сравнение
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (obj.GetType() != this.GetType()) return false;
                SuperString o = (SuperString)obj;
                return (this.str == o.str);
            }

            // Переопределение хэш кода
            public override int GetHashCode()
            {
                hex = string.IsNullOrEmpty(str) ? 0 : str.GetHashCode();
                return hex;
            } 
 
            // Метод для нахождение подстроки или строки в данной Строке
       public bool FindChars(string c)
            {
                if (str.IndexOf(c) == -1) return false;
                else return true;
            }

            public bool FindChars(SuperString c)
            {
                if (str.IndexOf(c.str) == -1) return false;
                else return true;
            }

            // Метод для замены синволов в данной СуперСтроке
            public bool CharFor(char c, char ci)
            {
              if(str.IndexOf(c)==-1)
                {
                    return false;
                }
                else
                {
                    str.Replace(c, ci);
                    return true;
                }     
            }
            // Метод для нахождение длины в данной СуперСтроке
            public int Chars()
            {
                return str.Length;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество СуперСтрок: ");
            int n = Convert.ToInt32(Console.ReadLine()) ;
            Console.WriteLine("Красава!");
            SuperString[] NewString = new SuperString[n];
            for (int counter = 1; counter <= n; counter++)
            {
                Console.WriteLine($"{counter} строка: ");
                NewString[counter-1] = new SuperString(Console.ReadLine());
            }
            Console.WriteLine("Введите количество синволов: ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Красава!");

            for (int counter = 1; counter <= n; counter++)
            {
                if(NewString[counter - 1].Chars()==c)
                Console.WriteLine($"{counter} строка: {NewString[counter - 1].str}");
              }
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();
            Console.WriteLine("Красава!");
            for (int counter = 1; counter <= n; counter++)
            {
                    if(NewString[counter - 1].FindChars(word))
                    Console.WriteLine($"{counter} строка: {NewString[counter - 1].str}");
            }
            Console.ReadLine();
             for (int counter = 1; counter <= n; counter++)
            {
               Console.WriteLine(NewString[counter - 1].ToString());
            }
            Console.ReadLine();

            var SomeTypeSuperString = new { str = "123", number = 10 };


            Console.ReadLine();
        }
    }
}