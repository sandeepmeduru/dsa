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
     * Complete the 'singlelement' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */

    public static int singlelement(int n, List<int> arr)
    {
        //0 1 2 3 4
        //1 1 2 2 3
        int start = 0, end = arr.Count - 1; //0, 4
        
        while (start <= end)
        {
            int mid = start + (end - start) / 2; //4
            
            if (mid == 0 || mid == arr.Count - 1 || (arr[mid] != arr[mid-1] && arr[mid] != arr[mid+1]))
            {
                return arr[mid];
            }
            
            if (mid % 2 == 1)
            {
                if (arr[mid] == arr[mid-1])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1; //0
                }
            }
            else
            {
                if (arr[mid] == arr[mid+1])
                {
                    start = mid + 2; //4
                }
                else
                {
                    end = mid - 1;
                }
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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.singlelement(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
