using ConsoleApp1.interfaces;

namespace ConsoleApp1.services;

public class DefaultHandler : IHandler
{
    public void Handle()
    {
        Console.WriteLine("your need select option, 1,2,3 or other");
        Program.Run();
    }
}