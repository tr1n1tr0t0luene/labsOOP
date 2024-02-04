using System;
using System.IO;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Task1.Start();
                    break;
                case 2:
                    Task2.Start();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}