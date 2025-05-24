using System.Text.RegularExpressions;
using ConsoleApp1.interfaces;

namespace ConsoleApp1.Services.Calculator;

public class Calculator : IHandler
{
    //todo: need refactoring 
    private List<string> _numbers, _options;
    public Calculator()
    {
        _numbers = new List<string>();
        _options = new List<string>();
    }

    public void Handle()
    {
        Console.WriteLine("input math expression");
        string optionsInStr = Console.ReadLine() ?? "";
        if (!CheckValidStr(optionsInStr))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error input");
            Console.ResetColor();
            return;
        }

        CreateList(optionsInStr);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(CaclculateTotal());
        Console.ResetColor();
    }

    private float CaclculateTotal()
    {
        string option;
        float firstNumber, secondNumber, result = 0;
        int indexOption = 0;
        while (_options.Count > 0)
        {
            if (_numbers.Count < 2 || _options.Count < 1)
            {
                Console.WriteLine("break");
                break;
            }
            option = _options[indexOption];
            
            if (_options.Contains("*") || _options.Contains("/"))
            {
                if (option != "*" && option != "/")
                {
                    indexOption++;
                    continue;
                }
            }
            
            firstNumber = float.Parse(_numbers[indexOption]);
            secondNumber = float.Parse(_numbers[indexOption + 1]);
            result = Calculate(option,firstNumber, secondNumber);

            _options.RemoveAt(indexOption);
            _numbers.RemoveAt(indexOption);
            _numbers.RemoveAt(indexOption);
            _numbers.Insert(indexOption, result.ToString());
            indexOption = 0;
        }
        
        return float.Parse(_numbers[0]);

    }
    private void CreateList(string optionsInStr)
    {
        var options = new List<string>();
        var numbers = new List<string>();

        const string patternNumber = @"\.|[0-9]"; 
        const string patternSigns = @"\*|\/|\+|\-";

        string temporaryStr = "";
        foreach (var charVar in optionsInStr)
        {
            string currentChar = charVar.ToString();

            var matchNumber = Regex.Match(currentChar, patternNumber);
            var matchSign = Regex.Match(currentChar, patternSigns);
            
            if (matchNumber.Success)
            {
                temporaryStr += matchNumber.Value; 
                continue;
            }
            if (matchSign.Success)
            {
                options.Add(matchSign.Value);
            }
            
            if (temporaryStr.Length > 0)
            {
                numbers.Add(temporaryStr);
                temporaryStr = "";
            }
        }
        if (temporaryStr.Length > 0) numbers.Add(temporaryStr);
        
        _options.AddRange(options);
        _numbers.AddRange(numbers);
    }
    private float Calculate(string option, float firstNumber, float secondNumber)
    {
        return option switch
        {
            "*" => firstNumber * secondNumber,
            "/" => firstNumber  / secondNumber,
            "+" => firstNumber + secondNumber,
            "-" => firstNumber - secondNumber,
            _ => 0
        };
    }

    private bool CheckValidStr(string str)
    {
        char[] validNumbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        string[] optionsSigns = ["*", "/", "+", "-"];
        bool valid = false;

        for (int i = 0; i < optionsSigns.Length; i++)
        {
            if (str.Contains(optionsSigns[i])) valid = true;
            if (valid) break;
        }

        if (!valid)
        {
            Console.WriteLine("not have expression");
            return false;
        }

        valid = false;
        for (int i = 0; i < validNumbers.Length; i++)
        {
            if (str.Contains(validNumbers[i])) valid = true;
            if (valid) break;
        }

        return valid;
    }
}