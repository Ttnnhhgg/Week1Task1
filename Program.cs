class Calculator
{
    static void Main()
    {
        Console.WriteLine("Калькулятор");
        while (true)
        {
            Calculate();
            if (!AskContinue())
                break;
        }
        Console.WriteLine("До свидания!");
    }
    static void Calculate()
    {
        try
        {
            double a = GetNumber("Первое число: ");
            char op = GetOperation();
            double b = GetNumber("Второе число: ");
            double result = CalculateResult(a, b, op);
            ShowResult(a, b, op, result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    static double GetNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.ToLower() ?? "";
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: Введена пустая строка!");
                continue;
            }
            if (double.TryParse(input, out double number))
                return number;
            Console.WriteLine("Ошибка: Введите корректное число!");
        }
    }
    static char GetOperation()
    {
        while (true)
        {
            Console.Write("Операция (+, -, *, /): ");
            string input = Console.ReadLine()?.ToLower() ?? "";
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: Введена пустая строка!");
                continue;
            }
            char op = input[0];
            if ("+-*/".Contains(op))
                return op;
            Console.WriteLine("Ошибка: Неизвестная операция!");
        }
    }
    static double CalculateResult(double a, double b, char op)
    {
        return op switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => b == 0 ? throw new DivideByZeroException("Деление на ноль невозможно!") : a / b,
            _ => throw new Exception("Неизвестная операция")
        };
    }
    static void ShowResult(double a, double b, char op, double result)
    {
        Console.WriteLine($"Результат: {a} {op} {b} = {result}");
    }
    static bool AskContinue()
    {
        while (true)
        {
            Console.Write("Еще расчет? (да/нет): ");
            string answer = Console.ReadLine()?.ToLower() ?? "";
            if (string.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine("Ошибка: Введена пустая строка!");
                continue;
            }
            Console.WriteLine();
            return answer == "да";
        }
    }
}
