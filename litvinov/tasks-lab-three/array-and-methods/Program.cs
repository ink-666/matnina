using System;

class Program
{
    static void Main()
    {
        int[] arr = CreateArray(10);

        Console.WriteLine("Массив до SwapHalves:");
        PrintArray(arr);

        SwapHalves(arr);

        Console.WriteLine("Массив после SwapHalves:");
        PrintArray(arr);

        int sum = SumArray(arr);
        double avg = AverageArray(arr, sum);

        Console.WriteLine("Сумма элементов: " + sum);
        Console.WriteLine("Среднее арифметическое: " + avg);
    }

    static int[] CreateArray(int size)
    {
        Random rnd = new Random();
        int[] result = new int[size];
        for (int i = 0; i < size; i++)
            result[i] = rnd.Next(-20, 21);
        return result;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }

    static void SwapHalves(int[] arr)
    {
        int half = arr.Length / 2;
        for (int i = 0; i < half; i++)
        {
            int temp = arr[i];
            arr[i] = arr[i + half];
            arr[i + half] = temp;
        }
    }

    static int SumArray(int[] arr)
    {
        int sum = 0;
        foreach (int x in arr)
            sum += x;
        return sum;
    }

    static double AverageArray(int[] arr, int sum)
    {
        return (double)sum / arr.Length;
    }
}
