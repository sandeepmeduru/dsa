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
     * Complete the 'majorityElement' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */

    public static int majorityElement(int n, List<int> arr)
    {
        int count = 1, currentElement = arr[0];
        
        for (int i = 1; i < n; i++)
        {
            if (arr[i] == currentElement)
            {
                count++;
            }
            else
            {
                count--;
            }
            
            if (count == 0)
            {
                currentElement = arr[i];
                count = 1;
            }
        }
        
        int currentElementCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == currentElement)
            {
                currentElementCount++;
            }
        }
        
        if (currentElementCount > n/2)
        {
            return currentElement;
        }
        return -1;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.majorityElement(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
