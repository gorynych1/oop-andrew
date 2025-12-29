using System;

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
     * Отчисление:
     * 1) программирование < 3 — отчислить
     * 2) два и более предмета < 3 — отчислить
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
}
#endregion
#region Array Wrapper with Indexer
public class StudentArray
{
    private readonly IStudent[] students;

    public int Length => students.Length;

    public StudentArray(int size)
    {
        students = new IStudent[size];
    }

    // Индексатор
    public IStudent this[int index]
    {
        get
        {
            if (index < 0 || index >= students.Length)
                throw new IndexOutOfRangeException();
            return students[index];
        }
        set
        {
            if (index < 0 || index >= students.Length)
                throw new IndexOutOfRangeException();
            students[index] = value;
        }
    }
}
#endregion
#region Task
static class Task_StackReplacedByArray
{
    public static void Run()
    {
        StudentArray students = new StudentArray(5);

        for (int i = 0; i < students.Length; i++)
            students[i] = Student.GenerateStudent();

        for (int i = students.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(students[i].GetStudentInfo());
            Console.WriteLine(
                students[i].GetDecision()
                    ? "Решение: оставить"
                    : "Решение: отчислить"
            );
            Console.WriteLine(new string('-', 40));
        }
    }
}

#endregion