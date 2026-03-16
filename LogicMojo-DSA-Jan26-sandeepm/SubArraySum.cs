class Solution {
    public List<int> SubarraySum(int[] arr, int target) {
        int i = 0, j = 0, currentSum = 0;
        List<int> result = new();
        
        while (j < arr.Length)
        {
            currentSum += arr[j];
            
            while (currentSum >= target)
            {
                if (currentSum > target)
                {
                    currentSum -= arr[i];
                    i++;
                }

                if (currentSum == target)
                {
                    result.Add(i+1);
                    result.Add(j+1);
                    return result;
                }
            }

            j++;
        }
        
        result.Add(-1);
        return result;
    }
}
