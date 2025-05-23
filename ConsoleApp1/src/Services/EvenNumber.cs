using ConsoleApp1.interfaces;

namespace ConsoleApp1.services;

public class EvenNumber : IHandler
{
    public void Handle()
    {
        Console.WriteLine("Input number");

        string input = Console.ReadLine() ?? "0";

        if (int.TryParse(input, out int result))
        {
            string strResult = result % 2 == 0 ? "Even" : "Odd";
            Console.WriteLine($"{input} is {strResult}");
        }
        else
        {
            Console.WriteLine("you entered an invalid number");
            Console.WriteLine("try again");
            Handle();
        }
    }
}