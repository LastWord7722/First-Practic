using ConsoleApp1.interfaces;

namespace ConsoleApp1.services;

public class SumTwoNumber : IHandler
{
    public void Handle()
    {
        Console.WriteLine("Input first number");
        string firstInput = Console.ReadLine() ?? "0";
        Console.WriteLine("Input second number");
        string secondInput = Console.ReadLine() ?? "0";
        
        Console.WriteLine(
            ToNumber(firstInput) + ToNumber(secondInput)
        );
    }

    private static int ToNumber(string? input)
    {
        return int.TryParse(input, out var result) ? result : 0;
    }
}