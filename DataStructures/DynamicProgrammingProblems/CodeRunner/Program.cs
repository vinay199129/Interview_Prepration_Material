// See https://aka.ms/new-console-template for more information
using DynamicProgrammingProblems;

Console.WriteLine("Hello, World!");

//Console.WriteLine(FibonacciSeries.Calc(50)); //12586269025

//Console.WriteLine(GridTraveller.Calc(3, 3)); //6
//Console.WriteLine(GridTraveller.Calc(18, 18)); //2333606220

//Console.WriteLine(SummingProblems.CanSum(7, new int[] { 2, 4 })); //false
//Console.WriteLine(SummingProblems.CanSum(8, new int[] { 2, 3, 5 })); //true
//Console.WriteLine(SummingProblems.CanSum(300, new int[] { 7, 14 })); //true

//howSum Problem
//Console.WriteLine($"[{String.Join(',', (SummingProblems.HowSum(7, new int[] { 5, 3, 4, 7 })) ?? new int[] { })}]"); //[4,3]
//Console.WriteLine($"[{String.Join(',', (SummingProblems.HowSum(7, new int[] { 2, 4 })) ?? new int[] { })}]"); //null
//Console.WriteLine($"[{String.Join(',', (SummingProblems.HowSum(8, new int[] { 2, 3, 5 })) ?? new int[] { })}]"); //[2,2,2,2]
//Console.WriteLine($"[{String.Join(',', (SummingProblems.HowSum(300, new int[] { 7, 14 })) ?? new int[] { })}]"); //null

//bestSum Problem
//Console.WriteLine($"[{String.Join(',', (SummingProblems.BestSum(7, new int[] { 5, 3, 4, 7 })) ?? new int[] { })}]"); //[3,4]
//Console.WriteLine($"[{String.Join(',', (SummingProblems.BestSum(8, new int[] { 2, 3, 5 })) ?? new int[] { })}]"); //[3,5]
//Console.WriteLine($"[{String.Join(',', (SummingProblems.BestSum(8, new int[] { 1, 4, 5 })) ?? new int[] { })}]"); //[4,4]
//Console.WriteLine($"[{String.Join(',', (SummingProblems.BestSum(100, new int[] { 1, 2, 5, 10, 25 })) ?? new int[] { })}]"); //[25,25,25,25]

//Console.WriteLine(StringCases.CanConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); //true
//Console.WriteLine(StringCases.CanConstruct("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar"})); //false
//Console.WriteLine(StringCases.CanConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); //true
//Console.WriteLine(StringCases.CanConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); //false

// Console.WriteLine(StringCases.CountConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" })); //2
// Console.WriteLine(StringCases.CountConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); //1
// Console.WriteLine(StringCases.CountConstruct("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" })); //0
// Console.WriteLine(StringCases.CountConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); //4
// Console.WriteLine(StringCases.CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); //0

PrintJaggedArray(StringCases.AllConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" }));
PrintJaggedArray(StringCases.AllConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" }));
PrintJaggedArray(StringCases.AllConstruct("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sx", "boar" }));
PrintJaggedArray(StringCases.AllConstruct("aaaaaaaaaaaaaaaaaf", new string[] { "aa", "aaa", "aaaa", "aaaaa", "aaaaa", "aaaaaa" }));
//Console.WriteLine(StringCases.AllConstruct("purple", new string[] { "purp", "le" }));

Console.ReadKey();


void PrintJaggedArray(string[][] jagged)
{
    Console.WriteLine("Result Start");
    if (jagged.Length > 0)
    {
        for (int i = 0; i < jagged.Length; i++)
        {
            string[] innerArray = jagged[i];
            Console.WriteLine($"[{string.Join(",", innerArray)}]");
        }
    }
    else {
        Console.WriteLine($"[]");
    }

    Console.WriteLine("Result End");
}
