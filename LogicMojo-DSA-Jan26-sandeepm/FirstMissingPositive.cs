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
     * Complete the 'first_missing_positive' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */

    public static int first_missing_positive(int n, List<int> arr)
    {
        int marker = n + 100;

        for(int i = 0; i < n; i++)
        {
            if (arr[i] <= 0 || arr[i] > n)
            {
                arr[i] = marker;
            }
        }
        
        for (int i = 0; i < n; i++)
        {
            int elementIndex = Math.Abs(arr[i]) - 1;
            if (elementIndex < n && arr[elementIndex] > 0)
            {
                arr[elementIndex] = -arr[elementIndex];
            }
        }
        
        for (int i = 0; i < n; i++)
        {            
            if (arr[i] > 0)
            {
                return i + 1;
            }
        }

        return n + 1;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.first_missing_positive(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
