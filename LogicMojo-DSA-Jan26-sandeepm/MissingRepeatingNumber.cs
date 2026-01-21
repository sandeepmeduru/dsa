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
     * Complete the 'find_missing' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> find_missing(List<int> arr)
    {
        List<int> answer = new List<int> { 0, 0 };
        
        for(int i = 0; i < arr.Count; i++)
        {
            int elementIndex = Math.Abs(arr[i]) - 1;
            if (arr[elementIndex] < 0)
            {
                answer[0] = elementIndex + 1;
                continue;
            }
            arr[elementIndex] = -arr[elementIndex];
        }
        
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] > 0)
            {
                answer[1] = i + 1;
                break;
            }
        }
        
        return answer;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.find_missing(arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
