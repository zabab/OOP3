using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

public class TowarException : Exception
{
    public TowarException(string message) : base(message)
    {
        
    }

}

public class PriceException : TowarException
{
    public PriceException(string message) : base(message)
    {
    }

}

public class BuyException : TowarException
{
    public BuyException(string message) : base(message)
    {
    }
}
public class AddException : TowarException
{
    public AddException(string message) : base(message)
    {
    }
}
//struct ERROR
//{
//    private enum Err {ErrAdd=1,ErrExit=40,ErrNET=404 }

//    public static void Msg(int a)
//    {
//        if(a==(int)Err.ErrAdd)
//        Console.WriteLine("Error 1");
//        else if(a== (int)Err.ErrExit)
//        Console.WriteLine("Error 40. ErrExit");
//        else if(a== (int)Err.ErrNET)
//        Console.WriteLine("Error 40. ErrNET.");


//    }
//}

namespace OOP5
{
    /*
                   [Товар] 
                    /
               [Техника] 
               / /    \ \
              / /      \ [Печатающее устройство]
             /[Сканер]  \
       [Компьютер]    [Планшет]
       
   */

    class Program
    {

        public interface IProduct
        {
            void Buy(int buycount);
            void Add(int addcount);
            void NewPrice(int price);
            void ShowPrice();
        }

        interface IComputer
        {
            void ShowPrice();
        }

        public abstract class Product
        {
            public string name;
            public double price;
            public int count;
            public int year;


            public double Price
            {
                get
                {
                    return price;
                }
                set
                {
                    price = value;
                }
            }
            public override string ToString()
            {
                return $"{GetType()}\n {name}: {price}$ x {count}k.";
            }

        }

        public class Technics : Product, IProduct
        {
            public int u;
            public int p;

            public void Buy(int buycount)
            {
                if (count >= buycount)
                {
                    count = count - buycount;
                    Console.WriteLine($"{buycount} products bought. {count} products left.");
                }
                else
                {
                    throw new BuyException("This product is not in stock.");
                }
            }
            public void Add(int addcount)
            {
                if (addcount < 0)
                {
                    throw new AddException("Number must be greater than zero.");
                }
                this.count = +addcount;
                Console.WriteLine($" Added {addcount} products. Total {count} products.");
            
        }

            public void NewPrice(int price)
            {
                if (price < 0) throw new PriceException("The price must be greater than zero.");
                this.price = price;
                Console.WriteLine($"The new price is {price}$.");

            }
            public void ShowPrice()
            {
                Console.WriteLine($"{name} \n Price:  {price}$");
            }

            public override string ToString()
            {
                return $"{GetType()}\n {name}: {price}$ x {count}k. \n U={u} \t P={p}";
            }

        }

        public class Printed_devices : Technics
        {
            public bool isItPrinter;
            public bool isItKseroks;

            public Printed_devices(string name, double price, int count, int u, int p, bool isItPrinter, bool isItkseroks, int year)
            {
                this.name = name;
                this.price = price;
                this.count = count;
                this.u = u;
                this.p = p;
                this.isItPrinter = isItPrinter;
                this.isItKseroks = isItkseroks;
                this.year = year;
            }

            public override string ToString()
            {
                string str;
                if (isItKseroks) str = "Kseroks";
                else if (isItPrinter) str = "Printer";
                else str = "WHAT IS IT?";
                return $"{GetType()}\n {name}: {price}$ x {count}k. \n U={u} \t P={p} \n {str}  \n Year: {year}";
            }
        }

        public class Skanner : Technics
        {
            int dpi;
            string size;

            public Skanner(string name, double price, int count, int u, int p, int dpi, string size, int year)
            {
                this.name = name;
                this.price = price;
                this.count = count;
                this.u = u;
                this.p = p;
                this.dpi = dpi;
                this.size = size;
                this.year = year;
            }
            public override string ToString()
            {
                return $"{GetType()}\n {name}: {price}$ x {count}k. \n U={u} \t P={p} \n Dpi: {dpi} Size: {size}  \n Year: {year}";
            }
        }

        sealed public class Computer : Technics, IComputer
        {
            public string processor;
            public string videocard;
            public int ozy;

            public Computer(string name, double price, int count, int u, int p, string processor, string videocard, int ozy, int year)
            {
                try
                {
                    if (price <= 0)
                    {
                        Exception PriceNull = new Exception();
                        throw PriceNull;
                    }
                    this.name = name;
                    this.price = price;
                    this.count = count;
                    this.u = u;
                    this.p = p;
                    this.processor = processor;
                    this.videocard = videocard;
                    this.year = year;
                    this.ozy = ozy;
                }
                catch (Exception)
                {

                    throw;
                }

            }

            void IComputer.ShowPrice()
            {
                Console.WriteLine($"{name}: [{processor}] + [{videocard}] + [{ozy} RAM]");
                Console.WriteLine($"Standard price:  {price}");
                Console.WriteLine($"Add 2G(40$) RAM:  {price + 40}");
                Console.WriteLine($"Add 4G(70$) RAM:  {price + 70}");
            }

            public override string ToString()
            {
                return $"{GetType()}\n {name}: {price}$ x {count}k. \n U={u} \t P={p} \n Processor:{processor} Video:{videocard} Ram:{ozy}  \n Year: {year}";
            }
            /* public void SmenaVideoCard(string n)
             {
                 videocard = n;
             }
             public void SmenaProcessora(string n)
             {
                 processor = n;
             }
             public void AddOzy(int n)
             {
                 ozy = n;
             }*/
        }

        public class Tablet : Technics
        {

            public string processor;
            public string opersystem;
            public int ozy;

            public Tablet(string name, double price, int count, int u, int p, string processor, string opersystem, int ozy, int year)
            {
                this.name = name;
                this.price = price;
                this.count = count;
                this.u = u;
                this.p = p;
                this.ozy = ozy;
                this.processor = processor;
                this.opersystem = opersystem;
                this.year = year;
            }
            public override string ToString()
            {
                return $"{GetType()}\n {name}: {price}$ x {count}k. \n U={u} \t P={p} \n Processor:{processor} OS:{opersystem} Ram:{ozy} \n Year: {year}";
            }

        }

        sealed public class Printer
        {
            public Printer() { }
            public string Print(IProduct obj)
            {
                return obj.ToString();
            }


        }

        public class lab<T> where T : Product
        {
            T[] items = new T[1];

            public void Add(T a)
            {

                int l = items.Length;
                System.Array.Resize(ref items, l + 1);
                items[l] = a;

            }

            public void Remove(int a)
            {
                int l = items.Length;
                for (int i = 1; i < l; i++)
                {
                    if (i == a - 1)
                    {
                        for (int ii = i; ii < l - 1; ii++)
                            items[ii - 1] = items[ii];
                        System.Array.Resize(ref items, l - 1);
                    }

                }
            }

            public string ListItems(int number)
            {
                return $"item {number} is \n {items[number].ToString()} ";
            }

            public int ListSize()
            {
                return items.Length;
            }

            public int Srok(int number)
            {
                return items[number].year;
            }

            public int AllFor(string name)
            {
                int i = 0;
                foreach (var item in items)
                {
                    if (item == null) continue;
                    if (item.GetType().Name == name)
                    {
                        i++;
                    }
                }
                return i;
            }

            public T[] Sort()
            {
                T[] itemsNew = items;
                T temp; // временная переменная для хранения элемента массива
                bool exit = false; // болевая переменная для выхода из цикла, если массив отсортирован

                while (!exit) // пока массив не отсортирован
                {
                    exit = true;
                    for (int int_counter = 1; int_counter < (itemsNew.Length - 1); int_counter++)


                        if (itemsNew[int_counter].price > itemsNew[int_counter + 1].price)
                        {
                            temp = itemsNew[int_counter];
                            itemsNew[int_counter] = itemsNew[int_counter + 1];
                            itemsNew[int_counter + 1] = temp;
                            exit = false;
                        }
                }
                return itemsNew;

            }
        }

        public class Controller
        {
            public int TotalElements = 0;
            private lab<Technics> obj;
            public Controller(lab<Technics> Product)
            {
                obj = Product;
            }

            public void GetList()
            {
                Console.WriteLine("List:");
                for (int i = 1; i < obj.ListSize(); i++)
                {
                    Console.WriteLine(obj.ListItems(i));
                }
            }

            public void GetListSrok(int year)
            {
                Console.WriteLine($"Srok >{year}:");
                for (int i = 1; i < obj.ListSize(); i++)
                {
                    if (obj.Srok(i) >= year)
                        Console.WriteLine(obj.ListItems(i));
                }
            }

            public void All()
            {
                Console.WriteLine($"Computer:{obj.AllFor("Computer")},Printed_devices:{obj.AllFor("Printed_devices")},Skanner:{obj.AllFor("Skanner")},Tablet:{obj.AllFor("Tablet")}");
            }
            public void SortAndList()
            {
                Technics[] newObj = obj.Sort();
                for (int i = 1; i < obj.ListSize(); i++)
                {
                    Console.WriteLine(obj.ListItems(i));
                }
            }
        }

        static void Main(string[] args)
        {
            {
                //            Computer PC1 = new Computer("Hp 310", 751.5, 4, 220, 3, "Intel core i5", "NVidea 980", 16384, 1);
                //            Printed_devices Printer1 = new Printed_devices("Canon i1900", 199.9, 20, 220, 5, true, true, 12);
                //            Skanner Skanner1 = new Skanner("Canon Lide 120", 59.9, 33, 220, 1, 600, "A3", 25);
                //            Technics IX = new Computer("‎Apple MacBook Air 13", 1312, 3, 220, 3, "Intel Core i5 5350U", " Intel HD Graphics 6000", 8192, 9);
                //            */
                //            /* 5 laba
                //             * Console.WriteLine("Show price in IProduct \n \n");
                //               ((IProduct)PC1).ShowPrice();
                //               Console.WriteLine("\n\n Show price in IComputer \n\n");
                //               ((IComputer)PC1).ShowPrice();

                //               Console.WriteLine("\n\n\nis\\as");
                //               IProduct NewProduct = IX;
                //               Console.WriteLine(NewProduct is Computer);
                //               Console.WriteLine(NewProduct is Product);
                //               Console.WriteLine(NewProduct is Program);

                //               Console.WriteLine("As 1:");
                //               Product a = NewProduct as Product;
                //               Console.WriteLine(a);
                //               Console.WriteLine("As 2:");
                //               Skanner b = NewProduct as Skanner;
                //               Console.WriteLine(b);

                //               Technics[] stock = new Technics[4];
                //               stock[0] = PC1;
                //               stock[1] = Printer1;
                //               stock[2] = Skanner1;
                //               stock[3] = IX;

                //               Console.WriteLine("I see in stock:");
                //               foreach (var item in stock)
                //               {
                //                   Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                //                   Console.WriteLine(item.ToString());
                //               } */

                ///*6 laba
                // Console.WriteLine("LABORATORY:");
                //  lab<Technics> laboratory = new lab<Technics>();

                //  laboratory.Add(PC1);
                //  laboratory.Add(Printer1);
                //  laboratory.Add(Skanner1);
                //  laboratory.Add(IX);



                //  Controller controller = new Controller(laboratory);

                //  Console.WriteLine("\n\nGETLIST\n");
                //  controller.GetList();


                //  Console.WriteLine("\n\nGETLISTSROK\n");
                //  controller.GetListSrok(10);

                //  Console.WriteLine("\n\nALL\n");
                //  controller.All();

                //  Console.WriteLine("\n\nSortAndList\n");
                //  controller.SortAndList();
                //}
            }

Computer PC1 = new Computer("Hp 310", 751.5, 5, 220, 3, "Intel core i5", "NVidea 980", 16384, 1);
Console.WriteLine(PC1);

bool Err = false;
try
{
    int zero = 1;//0/1
    int newprice = 100/zero; //-100 err/100
    int countbuy = 5;//10 err/5
    int countadd = 5;//-5 err/5

    Console.WriteLine($"\nTry to make a new price on {PC1.name} {newprice} dollars.");
    PC1.NewPrice(newprice);

    Console.WriteLine($"\nWe will try to buy {countbuy} {PC1.name}");
    PC1.Buy(countbuy);

    Console.WriteLine($"\nWe will try to add {countadd} {PC1.name}");
    PC1.Add(countadd);
  
                
            }
catch (PriceException exception)
{
    Console.WriteLine("Error: " + exception.Message);
    Console.WriteLine("Method: " + exception.TargetSite);
    Console.WriteLine("Source: " + exception.Source);
    Err = true;
}
catch (BuyException exception)
{
    Console.WriteLine("Error: " + exception.Message);
    Console.WriteLine("Method: " + exception.TargetSite);
    Console.WriteLine("Source: " + exception.Source);
    Err = true;

}
catch (AddException exception)
{
    Console.WriteLine("Error: " + exception.Message);
    Console.WriteLine("Method: " + exception.TargetSite);
    Console.WriteLine("Source: " + exception.Source);
    Err = true;

}
catch (Exception exception)+
{
    Console.WriteLine("Error: " + exception.Message);
    Console.WriteLine("Method: " + exception.TargetSite);
    Console.WriteLine("Source: " + exception.Source);
    Err = true;

}
finally
{
    if (Err == true)
    {
        Console.WriteLine("Errors processed.");
    }
    else
    {
        Console.WriteLine("All right.");
    }

}
bool isError = false;
Debug.Assert(isError); // проверяет, есть ли логическая ошибка при создании программы. Выбрасывает стек вызовов, если false
}
}
}
 