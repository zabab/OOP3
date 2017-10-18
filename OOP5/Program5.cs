using System;

public interface IВключение
{
    void TurnOn();
    void ToString();
}

public abstract class Товар
{
    public int kol=90;
    public abstract int Выгружено() ;
    public void TurnOn() { Console.WriteLine("Товар включает Технику, Мебель, Электронику, Сантехнику\n"); }
    virtual new public void ToString() { Console.WriteLine("Это абстрактный класс Товар. Количество товара ={0}\n",kol); }
}

public class Техника : Товар
{
    new public int kol = 70;
    public override int Выгружено()
    {
        return kol;
    }
    virtual public string Vse() { return "Техника включает Печатающее устройство, Сканер, Компьютер, Планшет\n"; }
    override public void ToString() { Console.WriteLine("Это класс Техника, наследуемый от Товар. Количество техники ={0}\n", kol); }
}

public class Печатающее_устройство : Техника
{
    public string vid="струйный";
    override public void ToString() { Console.WriteLine("Это класс Печатающее_устройство, наследуемый от Техника. Вид устройства ={0}\n", vid); }
}

public class Сканер : Техника
{
    public int speed=10;
    public override string Vse()
    {
        return "Рассмотрим Сканер";
    }
    override public void ToString() { Console.WriteLine("Это класс Сканер, наследуемый от Техника. Скорость работы ={0} стр/мин\n", speed); }
}

public class Компьютер : IВключение
{
    public void TurnOn()
    {
        Console.WriteLine("Компьютер включен\n");
    }
    public string OS="Linux";
    new public void ToString() { Console.WriteLine("Это класс Компьютер, наследуемый от интерфейса Включение. Тип ОС ={0}\n", OS); }
}

sealed public class Планшет : Техника
{
    public int a=30;
    public int b = 40;
    override public void ToString() { Console.WriteLine("Это класс Планшет, наследуемый от Техника. Размер ={0}x{1}\n", a,b); }
}

public class Printer
{
    public Printer(Товар А) { }
    public Printer(IВключение А) { }
    virtual public void IAmPrinting(Товар А) {
        Console.WriteLine(А.GetType());
        А.ToString();
    }
    virtual public void IAmPrinting(IВключение А)
    {
        Console.WriteLine(А.GetType());
        А.ToString();
    }
}

class TestProgramm
{
    static void Main()
    {

        Техника Сканер1 = new Сканер();
        IВключение Комп1 = new Компьютер();
        Товар перемещаемый = Сканер1 as Сканер;
        Техника Планш1 = new Планшет();
        Техника Принтер1 = new Печатающее_устройство();
        Комп1.TurnOn();
        Сканер1.TurnOn();
        Printer B = new Printer(Сканер1);
        B.IAmPrinting(перемещаемый);
        B.IAmPrinting(Сканер1);
        B.IAmPrinting(Принтер1);
        B.IAmPrinting(Планш1);
        B.IAmPrinting(Комп1);
    }
}