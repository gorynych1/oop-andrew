using System;
using System.Collections.Generic;
#region Interface
public interface IStudent
{
    string GetStudentInfo();
    bool GetDecision();
}
#endregion
#region Student
public class Student : IStudent
{
    private static readonly Random rnd = new Random();
    private static readonly string[] Names =
        { "Иван", "Петр", "Алексей", "Егор", "Дмитрий" };
    private static readonly string[] Surnames =
        { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };
    private static readonly string[] Patronymics =
        { "Иванович", "Петрович", "Алексеевич", "Дмитриевич", "Сергеевич" };
    private readonly string fullName;
    private readonly int programming;
    private readonly int philosophy;
    private readonly int networks;
    private readonly int optimization;
    private Student(
        string fullName,
        int programming,
        int philosophy,
        int networks,
        int optimization)
    {
        this.fullName = fullName;
        this.programming = programming;
        this.philosophy = philosophy;
        this.networks = networks;
        this.optimization = optimization;
    }
    public static Student GenerateStudent()
    {
        string name = Names[rnd.Next(Names.Length)];
        string surname = Surnames[rnd.Next(Surnames.Length)];
        string patronymic = Patronymics[rnd.Next(Patronymics.Length)];

        return new Student(
            $"{surname} {name} {patronymic}",
            rnd.Next(2, 6),
            rnd.Next(2, 6),
            rnd.Next(2, 6),
            rnd.Next(2, 6)
        );
    }

    public string GetStudentInfo()
    {
        return
            $"{fullName}\n" +
            $"Программирование: {programming}\n" +
            $"Философия: {philosophy}\n" +
            $"Сети: {networks}\n" +
            $"Методы оптимизации: {optimization}";
    }
    /*
     * Логика отчисления:
     * 1. Если программирование < 3 — отчислить сразу
     * 2. Если по двум и более предметам оценка < 3 — отчислить
     */
    public bool GetDecision()
    {
        if (programming < 3)
            return false;

        int badCount = 0;
        if (philosophy < 3) badCount++;
        if (networks < 3) badCount++;
        if (optimization < 3) badCount++;
        return badCount < 2;
    }
    public static Student CreateForTest(
        int programming,
        int philosophy,
        int networks,
        int optimization)
    {
        return new Student(
            "Тестовый Студент",
            programming,
            philosophy,
            networks,
            optimization
        );
    }
}

#endregion
#region Queue Task
static class Task3_QueueStudents
{
    public static void Run()
    {
        Queue<IStudent> queue = new Queue<IStudent>();
        for (int i = 0; i < 5; i++)
            queue.Enqueue(Student.GenerateStudent());
        while (queue.Count > 0)
        {
            IStudent student = queue.Dequeue();
            Console.WriteLine(student.GetStudentInfo());
            Console.WriteLine(
                student.GetDecision()
                    ? "Решение: оставить"
                    : "Решение: отчислить"
            );
            Console.WriteLine(new string('-', 40));
        }
    }
}
#endregion