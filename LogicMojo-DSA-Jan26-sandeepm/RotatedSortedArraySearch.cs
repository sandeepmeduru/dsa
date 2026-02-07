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
        int minIndex = GetMinElementIndex(arr);
        int i = 0, j = arr.Count-1;//0,2
        
        //2 0 1
        if (target >= arr[minIndex] && target <= arr[j])
        {
            return Search(arr, minIndex, j, target);
        }
        
        return Search(arr, i, minIndex-1, target);
    }
    
    private static int GetMinElementIndex(List<int> arr)
    {
        // 2 0 1
        int i = 0, j = arr.Count - 1; //0, 2
        
        while (i < j)
        {
            int mid = i + (j-i)/2; //0
            
            if (arr[mid] > arr[j])
            {
                i = mid + 1; //1
            }
            else if (arr[mid] < arr[j])
            {
                j = mid; // 1
            }
            else
            {
                j--;
            }
        }
        
        return i;
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
