using System;

static class Task2_BubbleSort
{
    public static void Run()
    {
        string[] surnames = { "Брусенцов", "Белоглазов", "Леонов" };

        for (int i = 0; i < surnames.Length - 1; i++)
            for (int j = 0; j < surnames.Length - i - 1; j++)
                if (string.Compare(surnames[j], surnames[j + 1]) > 0)
                {
                    string temp = surnames[j];
                    surnames[j] = surnames[j + 1];
                    surnames[j + 1] = temp;
                }

        foreach (var s in surnames)
            Console.WriteLine(s);
    }
}