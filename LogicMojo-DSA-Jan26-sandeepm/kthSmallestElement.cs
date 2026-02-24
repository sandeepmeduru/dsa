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
        return arr1.Count <= arr2.Count ? kthSmallest(arr1, arr2, k) : kthSmallest(arr2, arr1, k);
    }
    
    private static int kthSmallest(List<int> arr1, List<int> arr2, int k)
    {
        int low = Math.Max(0, k - arr2.Count), high = Math.Min(k, arr1.Count), left1 = -1, right1 = -1, left2 = -1, right2 = -1;
        
        //5 6 11    l=0,h=3
        //2 7 9 10  
        //1000      
        //1 2 3 4 5 6 7 8 9 10
        //10
        //2 4 8
        //1 2
        //3
        //1 6
        //1 2 3
        //5 7
        //8 9 10
        while (low <= high)
        {
            int mid1 = low + (high-low)/2; //2
            int mid2 = k - mid1;           //3-2=1
            
            left1 = (mid1-1) < 0 ? Int32.MinValue : arr1[mid1-1]; //6
            right1 = mid1 >= arr1.Count ? Int32.MaxValue : arr1[mid1]; //11
            
            left2 = (mid2-1) < 0 ? Int32.MinValue : arr2[mid2-1]; //2
            right2 = mid2 >= arr2.Count ? Int32.MaxValue : arr2[mid2]; //7
            
            if (left1 <= right2 && left2 <= right1)
            {
                break;
            }
            else if (left2 > right1)
            {
                low = mid1+1; //2
            }
            else
            {
                high = mid1-1; //0
            }
        }
        
        return Math.Max(left1, left2);
    }
    
    public static int kthSmallestTwoPointers(int n, List<int> arr1, int m, List<int> arr2, int k)
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
