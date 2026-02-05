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
     * Complete the 'search_element' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY arr
     *  2. INTEGER target
     */

    public static int search_element(List<int> arr, int target)
    {
        int minElementIndex = GetMinElementIndex(arr);
        
        int minElement = arr[minElementIndex];
        if (minElement == target)
        {
            return minElementIndex;
        }
        
        return minElementIndex == 0
            ? Search(arr, 0, arr.Count-1, target)
            : target >= arr[0] && target <= arr[minElementIndex-1]
                ? Search (arr, 0, minElementIndex-1, target)
                : Search (arr, minElementIndex+1, arr.Count-1, target);
    }
    
    private static int GetMinElementIndex(List<int> arr)
    {
        int i = 0, j = arr.Count - 1, mid = 0;
        
        while (i < j)
        {
            mid = i + (j-i)/2;
            
            if (arr[mid] <= arr[i])
            {
                j = mid - 1;
            }
            else
            {
                i = mid;
            }
        }
        
        return mid;
    }
    
    private static int Search(List<int> arr, int start, int end, int target)
    {
        while (start <= end)
        {
            int mid = start + (end-start) / 2;
            
            if (arr[mid] == target)
            {
                return mid;
            }
            
            if (arr[mid] < target)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
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

        int target = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.search_element(arr, target);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
