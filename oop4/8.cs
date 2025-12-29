using System;
using System.Collections.Generic;

static class Task8_StackThink
{
    public static void Run()
    {
        Stack<Think> stack = new Stack<Think>();

        for (int i = 0; i < 5; i++)
            stack.Push(Think.GenerateThink());

        while (stack.Count > 0)
        {
            Think t = stack.Pop();
            Console.WriteLine(t.GetThinkInfo());
            Console.WriteLine(t.GetDecision() ? "Хорошая мысль" : "Плохая мысль");
        }
    }
}

enum TypeThink { Study, Food, Games }

class Think
{
    static Random rnd = new Random();
    TypeThink type;

    public static Think GenerateThink()
    {
        return new Think { type = (TypeThink)rnd.Next(0, 3) };
    }

    public string GetThinkInfo() => type.ToString();

    public bool GetDecision() => type == TypeThink.Study;
}