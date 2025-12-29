using System;

static class Task7_InsertionSort
{
    public static void Run()
    {
        string[] names = { "Иван", "Пётр", "Дмитрий", "Анна" };

        for (int i = 1; i < names.Length; i++)
        {
            string key = names[i];
            int j = i - 1;

            while (j >= 0 && string.Compare(names[j], key) > 0)
            {
                names[j + 1] = names[j];
                j--;
            }
            names[j + 1] = key;
        }

        foreach (var n in names)
            Console.WriteLine(n);
    }
}