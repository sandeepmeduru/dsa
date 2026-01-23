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
     * Complete the 'maxProfit' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY nums
     *  2. INTEGER n
     */

    public static int maxProfit(List<int> nums, int n)
    {
        int minSoFar = nums[0], maxProfit = Int32.MinValue;
        
        for (int i = 1; i < n; i++)
        {
            minSoFar = Math.Min(minSoFar, nums[i]);
            maxProfit = Math.Max(maxProfit, nums[i] - minSoFar);
        }
        
        return maxProfit;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> price = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(priceTemp => Convert.ToInt32(priceTemp)).ToList();

        int profit = Result.maxProfit(price, n);

        textWriter.WriteLine(profit);

        textWriter.Flush();
        textWriter.Close();
    }
}
