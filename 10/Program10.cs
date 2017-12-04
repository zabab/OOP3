using System;

namespace Delegate
{
    public class WorksWithStrings
    {
        public event Func<string, string> Trimed;

        public event Action<string> Uppercase;
        public void Uppercased(string str)
        {
            string str1;
            str1 = str.ToUpper();
            string error = "Error";
            if (Uppercase != null)
            {
                Uppercase(str1);
            }
            else
            {
                if (Uppercase != null)
                {
                    Uppercase(error);
                }
            }
        }

        public void Trims(string str)
        {
            string MyString;
            char[] MyChar = { '+', '.', '/', ',', '!' };

            MyString = str.TrimEnd(MyChar);
            string MyString1;
            MyString1 = MyString.TrimStart(MyChar);
            string error = "Error";

            if (Trimed != null)
            {
                Trimed(MyString1);
            }
            else
            {
                if (Trimed != null)
                {
                    Trimed(error);
                }
            }
        }
        private static string Show_string(string stre)
        {
            Console.WriteLine(stre);
            return stre;
        }
        private static void Show(string stre)
        {
            Console.WriteLine(stre);
        }
        static void Main(string[] args)
        {
            WorksWithStrings str = new WorksWithStrings();
            string string1 = "!dfjbrgrgrg!,,!";
            str.Trimed += Show_string;
            str.Trims(string1);

            str.Uppercase += Show;
            str.Uppercased(string1);
        }
    }
}
