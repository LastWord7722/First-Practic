namespace ConsoleApp1;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Input first number");
        string firstInput = Console.ReadLine() ?? "0";
        Console.WriteLine("Input second number");
        string secondInput = Console.ReadLine() ?? "0";
        Console.WriteLine(firstInput);
        Console.WriteLine(secondInput);

        //Int32
        Console.WriteLine(
            ToNumber(firstInput) + ToNumber(secondInput)
        );
    }

    private static int ToNumber(string? input)
    {
        return int.TryParse(input, out var result) ? result : 0;
    }
}