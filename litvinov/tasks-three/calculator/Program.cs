using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Литвинов Семён");
        Console.WriteLine("Группа: 24/ИП-391к");
        Console.WriteLine("Дата: 04.09.2026");
        Console.WriteLine("Учебная практика");

        Console.Write("Введите первое число: ");
        int a = int.Parse(Console.ReadLine()!);

        Console.Write("Введите второе число: ");
        int b = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Сумма: " + (a + b));
        Console.WriteLine("Разность: " + (a - b));
        Console.WriteLine("Произведение: " + (a * b));
        Console.WriteLine("Частное: " + (a / b) + " (целочисленное деление, поэтому 7 / 2 = 3)");
    }
}
