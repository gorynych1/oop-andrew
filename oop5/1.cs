using System;
using System.IO;

static class Task1
{
    public static void Run()
    {
        string groupName = "IVT_21";
        string fileName = $"{groupName}.txt";
        string backupFile = $"{groupName}_backup.txt";

        string[] students =
        {
            "Иванов Иван",
            "Петров Петр",
            "Сидоров Алексей",
            "Кузнецов Дмитрий"
        };

        File.WriteAllLines(fileName, students);

        File.Copy(fileName, backupFile, true);

        File.Delete(fileName);
    }
}