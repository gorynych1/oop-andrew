using System;

static class Task6_SplitArray
{
    public static void Run()
    {
        string[] mixed = { "Иванов", "Иван", "Петров", "Пётр" };

        string[] surnames = new string[mixed.Length / 2];
        string[] names = new string[mixed.Length / 2];

        for (int i = 0; i < mixed.Length; i++)
        {
            if (i % 2 == 0) surnames[i / 2] = mixed[i];
            else names[i / 2] = mixed[i];
        }

        Console.WriteLine("Фамилии:");
        foreach (var s in surnames) Console.WriteLine(s);

        Console.WriteLine("Имена:");
        foreach (var n in names) Console.WriteLine(n);
    }
}