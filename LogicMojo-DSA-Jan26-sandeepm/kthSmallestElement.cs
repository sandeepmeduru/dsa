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
     * Complete the 'kthSmallest' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr1
     *  3. INTEGER m
     *  4. INTEGER_ARRAY arr2
     *  5. INTEGER k
     */

    public static int kthSmallest(int n, List<int> arr1, int m, List<int> arr2, int k)
    {
        int i = 0, j = 0, elementCount = 0, result = Int32.MinValue;
        
        while (i < arr1.Count && j < arr2.Count)
        {
            if (arr1[i] <= arr2[j])
            {
                result = arr1[i++];
            }
            else
            {
                result = arr2[j++];
            }
            
            elementCount++;
            if (elementCount == k)
            {
                break;
            }
        }
        
        while (i < arr1.Count && elementCount < k)
        {
            result = arr1[i++];
            elementCount++;
        }
        
        while (j < arr2.Count && elementCount < k)
        {
            result = arr2[j++];
            elementCount++;
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr1 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arr1Temp => Convert.ToInt32(arr1Temp)).ToList();

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr2 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arr2Temp => Convert.ToInt32(arr2Temp)).ToList();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.kthSmallest(m, arr1, n, arr2, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
