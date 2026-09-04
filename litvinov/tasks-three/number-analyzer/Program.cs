using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество чисел N: ");
        int n = int.Parse(Console.ReadLine()!);

        if (n == 0)
        {
            Console.WriteLine("Числа не введены");
            return;
        }

        int positive = 0, negative = 0, zeros = 0;
        int sum = 0;
        int max = int.MinValue;
        int min = int.MaxValue;

        // используем for, так как заранее известно количество чисел N
        for (int i = 0; i < n; i++)
        {
            Console.Write("Введите число " + (i + 1) + ": ");
            int x = int.Parse(Console.ReadLine()!);

            if (x > 0) positive++;
            else if (x < 0) negative++;
            else zeros++;

            sum += x;

            if (x > max) max = x;
            if (x < min) min = x;
        }

        double average = (double)sum / n;

        Console.WriteLine("Положительных: " + positive);
        Console.WriteLine("Отрицательных: " + negative);
        Console.WriteLine("Нулей: " + zeros);
        Console.WriteLine("Сумма: " + sum);
        Console.WriteLine("Максимум: " + max);
        Console.WriteLine("Минимум: " + min);
        Console.WriteLine("Среднее арифметическое: " + average);
    }
}
