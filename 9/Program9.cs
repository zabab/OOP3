using System;

namespace ConsoleApplication1
{
    delegate void Атака();
    delegate void Лечить();

    class Игра
    {
        // Объявляем событие
        public event Атака UserEvent;
        public event Лечить UserEvent1;

        // Используем метод для запуска события
        public void OnUserEvent()
        {
            UserEvent();
        }
        public void OnUserEvent1()
        {
            UserEvent1();
        }
    }
    class Info
    {
        string наименование;
        int здоровье=-10, снаряды=-50;
       
        public Info(string Наименование,int Здоровье, int Снаряды)
        {
            this.наименование = Наименование;
            this.здоровье = this.здоровье + Здоровье;
            this.снаряды = this.снаряды + Снаряды;
        }
        public string Наименование { set { наименование = value; } get { return наименование; } }
        public int Здоровье { set { здоровье = value; } get { return здоровье; } }
        public int Снаряды { set { снаряды = value; } get { return снаряды; } }
        // Обработчик события Атака
        public void UserInfoHandler()
        {
            Console.WriteLine("Произошла атака!!!");
            Console.WriteLine("{0}:",Наименование);
            Console.WriteLine("здоровье {0}%\n снаряды {1}\n", Здоровье, Снаряды);
        }
    }
    class Info1
    {
        string наименование;
        int здоровье=10, снаряды=50;
        public Info1(string Наименование, int Здоровье, int Снаряды)
        {
            this.наименование = Наименование;
            this.здоровье = Здоровье+this.здоровье;
            this.снаряды = Снаряды + this.снаряды;
        }
        public string Наименование { set { наименование = value; } get { return наименование; } }
        public int Здоровье { set { здоровье = value; } get { return здоровье; } }
        public int Снаряды { set { снаряды = value; } get { return снаряды; } }
        // Обработчик события Лечение
        public void UserInfoHandler()
        {
            Console.WriteLine("Лечение!");
            Console.WriteLine("{0}:", Наименование);
            Console.WriteLine("Было добавлено 10% здоровья и 50 снарядов. Теперь здоровье - {0}, снаряды - {1}", Здоровье, Снаряды);
        }
    }
    class Program
    {
        static void Main()
        {
            Игра битва_миномётов = new Игра();
            Info миномёт1 = new Info(Наименование:"Миномёт-1",Здоровье: 100, Снаряды:300);
            Info миномёт2 = new Info(Наименование:"Миномёт-2",Здоровье: 100, Снаряды: 250);
            Info1 миномёт3 = new Info1(Наименование:"Миномёт-3", Здоровье:50, Снаряды:200);

            // Добавляем обработчик события
            битва_миномётов.UserEvent += миномёт1.UserInfoHandler;
            битва_миномётов.UserEvent += миномёт2.UserInfoHandler;
            битва_миномётов.UserEvent1 += миномёт3.UserInfoHandler;
            // Запустим событие
            битва_миномётов.OnUserEvent();
            битва_миномётов.OnUserEvent1();
        }
    }
}