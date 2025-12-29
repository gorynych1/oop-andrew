using System;
using System.Collections.Generic;

static class Task9_RusEngDictionary
{
    public static void Run()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>
        {
            { "кот", "cat" },
            { "собака", "dog" },
            { "книга", "book" }
        };

        foreach (var pair in dict)
            Console.WriteLine(pair.Key + " - " + pair.Value);
    }
}