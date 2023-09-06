using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'getMax' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY operations as parameter.
     */

    public static List<int> getMax(List<string> operations)
    {
        //as we are using stack datatype we dont need to maintain length
        Stack operationStack = new Stack();
        //start with 1 as we dont need the 0 for setting length
        for(int i = 1; i == operations.Count; i++){
            Tuple<string, string> operationData = operations[i].Split(' ').ToList().Select(x=> new Tuple<string, string>(x[0], x[1]));
            Console.WriteLine($"{operationData.Item1}, {operationData.Item2}");
        }
        
    }
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> ops = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string opsItem = Console.ReadLine();
            ops.Add(opsItem);
        }

        List<int> res = Result.getMax(ops);

        textWriter.WriteLine(String.Join("\n", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
