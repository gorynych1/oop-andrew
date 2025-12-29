using System;

static class Task1_MergeArrays
{
    public static void Run()
    {
        string[] surnames = { "Брусенцов", "Белоглазов", "Леонов" };
        string[] names = { "Егор", "Андрей", "Владислав" };

        string[] array = new string[surnames.Length * 2];

        for (int i = 0; i < surnames.Length; i++)
        {
            array[i * 2] = surnames[i];
            array[i * 2 + 1] = names[i];
        }

        for (int i = 0; i < array.Length; i += 2)
            Console.WriteLine(array[i] + " " + array[i + 1]);
    }
}