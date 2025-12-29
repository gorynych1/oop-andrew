using System;
using System.Collections.Generic;

static class Task4_EngRusDictionary
{
    public static void Run()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>
        {
            { "cat", "кот" },
            { "dog", "собака" },
            { "book", "книга" }
        };

        foreach (var pair in dict)
            Console.WriteLine(pair.Key + " - " + pair.Value);
    }
}