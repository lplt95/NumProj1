using System;
using static System.Console;

namespace NumProj1
{
    class Program
    {
        static void Main(string[] args)
        {
            int selectedMethod = 0;
            WriteLine("Wybierz metodę: ");
            WriteLine("1. Metoda bisekcji");
            WriteLine("2. Metoda siecznych");
            WriteLine("3. Metoda stycznych");
            bool isCorrect;
            do
            {
                isCorrect = true;
                Int32.TryParse(ReadLine(), out selectedMethod);
                switch (selectedMethod)
                {
                    case 1:
                        WriteLine("Wybrałeś metodę 1");
                        
                        break;
                    case 2:
                        WriteLine("Wybrałeś metodę 2");
                        
                        break;
                    case 3:
                        WriteLine("Wybrałeś metodę 3");
                        break;
                    default:
                        WriteLine("Wybrałeś złą metodę. Spróbuj jeszcze raz.");
                        isCorrect = false;
                        break;
                }
            }
            while (!isCorrect);
        }
    }
}
