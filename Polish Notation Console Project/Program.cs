using System;
using Calculator;

namespace Polish_Notation_Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input string");
            string input = Console.ReadLine();

            Console.WriteLine(PolishNotation.Calculate(input)); 
        }
    }
}