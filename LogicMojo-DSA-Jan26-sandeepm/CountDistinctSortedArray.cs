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
     * Complete the 'findDistinctCount' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */

    public static int findDistinctCount(int n, List<int> arr)
    {
        int left = 0, right = arr.Count - 1, distinctCount = 0, lastSeen = Int32.MaxValue, currentMax = -1;

        while (left <= right)
        {
            int leftAbs = Math.Abs(arr[left]);
            int rightAbs = Math.Abs(arr[right]);
            
            if (leftAbs >= rightAbs)
            {
                currentMax = leftAbs;
                left++;
            }
            else
            {
                currentMax = rightAbs;
                right--;
            }
            
            if (currentMax != lastSeen)
            {
                distinctCount++;
                lastSeen = currentMax;
            }
        }
        
        return distinctCount;
    }
    
    public static int findDistinctCountAlternate(int n, List<int> arr)
    {
        int left = 0, right = arr.Count - 1, distinctElementCount = 0;
        
        while (left <= right)
        {
            distinctElementCount++;
            int currentElement = Math.Abs(arr[left]);
            
            while (left < arr.Count && Math.Abs(arr[left]) == currentElement)
            {
                left++;
            }
            
            while (right >=0 && Math.Abs(arr[right]) == currentElement)
            {
                right--;
            }
        }
        return distinctElementCount;
    }    
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.findDistinctCount(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
