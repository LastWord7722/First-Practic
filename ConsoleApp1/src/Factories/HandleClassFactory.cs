using ConsoleApp1.interfaces;
using ConsoleApp1.services;

namespace ConsoleApp1.factories;

public class HandleClassFactory : IHandleFactory
{
    private readonly int? _selectOption;
    
    public HandleClassFactory(int? selectOption)
    {
        _selectOption = selectOption;
    }

    private static readonly Dictionary<int, Type> ClassesMap = new Dictionary<int, Type>
    {
        { 1, typeof(SumTwoNumber) },
        { 2, typeof(EvenNumber) },
        // add more
    };

    public IHandler GetHandler()
    {
        if (_selectOption == null)
        {
            return new DefaultHandler();
        }

        return ClassesMap.TryGetValue(_selectOption.Value, out Type value)
            ? (IHandler)Activator.CreateInstance(value)!
            : new DefaultHandler();
    }
}
