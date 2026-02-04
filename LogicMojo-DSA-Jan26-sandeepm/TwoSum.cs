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
     * Complete the 'twoSum' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER target
     *  2. INTEGER n
     *  3. INTEGER_ARRAY arr
     */

    public static List<int> twoSum(int target, int n, List<int> arr)
    {
        int i = 0, j = arr.Count - 1;
        
        while (i < j)
        {
            int sum = arr[i] + arr[j];
            
            if (sum == target)
            {
                return new List<int> {i+1, j+1};
            }
            
            if (sum < target)
            {
                i++;
            }
            else
            {
                j--;
            }
        }
        
        return new List<int> {-1,-1};
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int targert = Convert.ToInt32(Console.ReadLine().Trim());

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.twoSum(targert, n, arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
