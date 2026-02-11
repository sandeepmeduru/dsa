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
     * Complete the 'longestSubstringWithoutRepeatingCharacters' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int longestSubstringWithoutRepeatingCharacters(string s)
    {
        Dictionary<char, int> frequencyMap = new();
        int i = 0, j = 0, maxSubstrLength = 0;
        
        while (j < s.Length)
        {
            char currentChar = s[j];
            frequencyMap[currentChar] = frequencyMap.GetValueOrDefault(currentChar, 0) + 1;
            
            while (frequencyMap[currentChar] > 1)
            {
                frequencyMap[s[i]]--;
                i++;
            }
            
            maxSubstrLength = Math.Max(maxSubstrLength, j-i+1);
            j++;
        }
        
        return maxSubstrLength;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.longestSubstringWithoutRepeatingCharacters(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
