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
     * Complete the 'median_array' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY nums1
     *  2. INTEGER_ARRAY nums2
     */

    public static string median_array(List<int> nums1, List<int> nums2)
    {
        if (nums1.Count == 0 && nums2.Count == 0)
        {
            return "-1.0";
        }

        if (nums1.Count > nums2.Count)
        {
            return median_array(nums2, nums1);
        }
        
        Console.WriteLine("Test debug message");

        double median = 0;
        int totalElements = nums1.Count + nums2.Count;
        int k = (totalElements+1) /2;
        int low = 0, high = nums1.Count;

        while (low <= high)
        {
            int mid1 = low + (high-low)/2;
            int mid2 = k - mid1;
            
            int left1 = (mid1-1) < 0 ? Int32.MinValue : nums1[mid1-1];
            int right1 = mid1 >= nums1.Count ? Int32.MaxValue : nums1[mid1];
            
            int left2 = (mid2-1) < 0 ? Int32.MinValue : nums2[mid2-1];
            int right2 = mid2 >= nums2.Count ? Int32.MaxValue : nums2[mid2];
            
            if (left1 <= right2 && left2 <= right1)
            {
                if (totalElements % 2 == 1)
                {
                    median = Math.Max(left1, left2);
                }
                else
                {
                    median = ((double)Math.Max(left1, left2) + (double)Math.Min(right1, right2))/2.0;
                }
                break;
            }
            else if (left2 > right1)
            {
                low = mid1+1;
            }
            else
            {
                high = mid1-1;
            }
        }

        return median.ToString("0.0");
    }
    
    private static int kthElement(List<int> arr1, List<int> arr2, int k)
    {
        int low = Math.Max(0, k - arr2.Count), high = Math.Min(k, arr1.Count), left1 = -1, right1 = -1, left2 = -1, right2 = -1;

        while (low <= high)
        {
            int mid1 = low + (high-low)/2;
            int mid2 = k - mid1;
            
            left1 = (mid1-1) < 0 ? Int32.MinValue : arr1[mid1-1];
            right1 = mid1 >= arr1.Count ? Int32.MaxValue : arr1[mid1];
            
            left2 = (mid2-1) < 0 ? Int32.MinValue : arr2[mid2-1];
            right2 = mid2 >= arr2.Count ? Int32.MaxValue : arr2[mid2];
            
            if (left1 <= right2 && left2 <= right1)
            {
                break;
            }
            else if (left2 > right1)
            {
                low = mid1+1;
            }
            else
            {
                high = mid1-1;
            }
        }
        
        return Math.Max(left1, left2);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> nums1 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(nums1Temp => Convert.ToInt32(nums1Temp)).ToList();

        List<int> nums2 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(nums2Temp => Convert.ToInt32(nums2Temp)).ToList();

        string result = Result.median_array(nums1, nums2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
