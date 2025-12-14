using System;
using System.Linq;
using System.Collections.Generic;

namespace Classroom
{
    public class ClassRoom
    {
        private List<Pupil> pupils;

        public ClassRoom(params Pupil[] pupilsList)
        {
            if (pupilsList.Length != 4)
                throw new ArgumentException("В классе должно быть 4 ученика");

            pupils = new List<Pupil>(pupilsList);
        }

        public double GetRoundGrade
        {
            get
            {
                double average = pupils.Average(p => p.GetCurrentGrade);
                return Math.Round(average, 2);
            }
        }

        public void ConductLesson()
        {
            Console.WriteLine("\n=== НАЧАЛО УРОКА ===");
            
            foreach (var pupil in pupils)
            {
                Console.WriteLine($"\n--- {pupil.Name} ---");
                Console.Write("Учеба: "); pupil.Study();
                Console.Write("Чтение: "); pupil.Read();
                Console.Write("Письмо: "); pupil.Write();
                Console.Write("Отдых: "); pupil.Relax();
                Console.WriteLine($"📝 Текущая оценка: {pupil.GetCurrentGrade}");
            }
        }
    }
}