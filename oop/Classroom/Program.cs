using System;

namespace Classroom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🎓 СИСТЕМА УПРАВЛЕНИЯ КЛАССОМ\n");

            var classroom = new ClassRoom(
                new ExcellentPupil { Name = "Анна" },
                new GoodPupil { Name = "Борис" },
                new BadPupil { Name = "Виктория" },
                new GoodPupil { Name = "Григорий" }
            );

            for (int lesson = 1; lesson <= 3; lesson++)
            {
                Console.WriteLine($"\n🎯 УРОК #{lesson}");
                Console.WriteLine("=" + new string('=', 30));
                classroom.ConductLesson();
                
                Console.WriteLine($"\n📊 СРЕДНИЙ БАЛЛ КЛАССА: {classroom.GetRoundGrade}");
                
                if (lesson < 3)
                {
                    Console.WriteLine("\n--- Перемена ---");
                    System.Threading.Thread.Sleep(2000);
                }
            }

            Console.WriteLine("\n🏫 Учебный день завершен!");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}