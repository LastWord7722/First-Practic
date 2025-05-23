using ConsoleApp1.factories;
using ConsoleApp1.interfaces;

namespace ConsoleApp1;

internal static class Program
{
    private static void Main(string[] args)
    {
        Run();
    }

    public static void Run()
    {
        Console.WriteLine("Select options:\n 1) two sum \n 2) check even number");
        string choice = Console.ReadLine() ?? "-1";
        //todo: need factory to static class 
        IHandleFactory factory = new HandleClassFactory(int.TryParse(choice, out int result) ? result : -1);
        IHandler handleClass = factory.GetHandler();
        handleClass.Handle();
        
        Console.WriteLine("You can start again? input yes or no");
        string repeat = Console.ReadLine() ?? "no";
        if (repeat.ToLower() == "yes" || repeat.ToLower() == "y")
        {
            Run();
        }
    }
}