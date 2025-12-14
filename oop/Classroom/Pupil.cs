using System;

namespace Classroom
{
    public abstract class Pupil
    {
        public string Name { get; set; } = "Ученик";
        private static Random random = new Random();

        public virtual int GetCurrentGrade
        {
            get
            {
                return random.Next(2, 6);
            }
        }

        public abstract void Study();
        public abstract void Read();
        public abstract void Write();
        public abstract void Relax();
    }

    public sealed class ExcellentPupil : Pupil
    {
        public override int GetCurrentGrade
        {
            get
            {
                int chance = new Random().Next(1, 101);
                if (chance <= 80) return new Random().Next(4, 6);
                return new Random().Next(3, 5);
            }
        }

        public override void Study() => 
            Console.WriteLine($"{Name} учится отлично! 📚");

        public override void Read() => 
            Console.WriteLine($"{Name} читает быстро и внимательно! 📖");

        public override void Write() => 
            Console.WriteLine($"{Name} пишет грамотно и аккуратно! ✍️");

        public override void Relax() => 
            Console.WriteLine($"{Name} отдыхает продуктивно! 🎯");
    }

    public sealed class GoodPupil : Pupil
    {
        public override int GetCurrentGrade
        {
            get
            {
                int chance = new Random().Next(1, 101);
                if (chance <= 60) return new Random().Next(4, 6);
                return new Random().Next(3, 5);
            }
        }

        public override void Study() => 
            Console.WriteLine($"{Name} учится хорошо! 📘");

        public override void Read() => 
            Console.WriteLine($"{Name} читает уверенно! 📗");

        public override void Write() => 
            Console.WriteLine($"{Name} пишет с небольшими ошибками! 📝");

        public override void Relax() => 
            Console.WriteLine($"{Name} отдыхает умеренно! 🎲");
    }

    public sealed class BadPupil : Pupil
    {
        public override int GetCurrentGrade
        {
            get
            {
                int chance = new Random().Next(1, 101);
                if (chance <= 30) return new Random().Next(4, 6);
                return new Random().Next(2, 4);
            }
        }

        public override void Study() => 
            Console.WriteLine($"{Name} учится с трудом! 📓");

        public override void Read() => 
            Console.WriteLine($"{Name} читает медленно! 📕");

        public override void Write() => 
            Console.WriteLine($"{Name} пишет с ошибками! 💢");

        public override void Relax() => 
            Console.WriteLine($"{Name} много отдыхает! 🎮");
    }
}