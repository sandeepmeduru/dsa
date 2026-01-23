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
     * Complete the 'rain_water' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY hei as parameter.
     */

    public static int rain_water(List<int> hei)
    {
        int n = hei.Count;

        int[] leftBoundaries = new int[n];
        leftBoundaries[0] = 0;
        for (int i = 1; i < n; i++)
        {
            leftBoundaries[i] = Math.Max(hei[i-1], leftBoundaries[i-1]);
        }
        
        int[] rightBoundaries = new int[n];
        rightBoundaries[n-1] = 0;
        for (int i = n-2; i >= 0; i--)
        {
            rightBoundaries[i] = Math.Max(hei[i+1], rightBoundaries[i+1]);
        }
        
        int rainWaterTrapped = 0;
        for (int i = 0; i < n; i++)
        {
            int minBoundary = Math.Min(leftBoundaries[i], rightBoundaries[i]);
            int valleyHeight = minBoundary - hei[i];
            rainWaterTrapped += valleyHeight < 0 ? 0 : valleyHeight;
        }
        
        return rainWaterTrapped;
    }

    private static int rain_water_bruteforce(List<int> hei)
    {
        int[] minHeights = new int[hei.Count];
        
        for (int i = 1; i < hei.Count; i++)
        {
            int leftMaxHeight = 0;
            for (int j = 0; j < i; j++)
            {
                leftMaxHeight = Math.Max(leftMaxHeight, hei[j]);
            }
            
            int rightMaxHeight = 0;
            for (int j = i + 1; j < hei.Count; j++)
            {
                rightMaxHeight = Math.Max(rightMaxHeight, hei[j]);
            }
            
            minHeights[i] = Math.Min(leftMaxHeight, rightMaxHeight);
        }
        
        int rainWaterTrapped = 0;
        for (int i = 1; i < hei.Count; i++)
        {
            int currentSlotWater = minHeights[i] - hei[i];
            rainWaterTrapped += currentSlotWater < 0 ? 0 : currentSlotWater ;
        }
        
        return rainWaterTrapped;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> hei = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(heiTemp => Convert.ToInt32(heiTemp)).ToList();

        int result = Result.rain_water(hei);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
