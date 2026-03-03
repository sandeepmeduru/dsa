public class Solution {
    public int FindDuplicate(int[] nums) {
        int n = nums.Length - 1;
        int start = 1, end = n, mid=0;

        while (start < end)
        {
            mid = start + (end-start)/2;//1
            int midRangeCount = 0;
            for (int i = 0; i <= n; i++)
            {
                if (nums[i] <= mid)
                {
                    midRangeCount++;
                }
            }

            if (midRangeCount > mid)
            {
                end = mid;//2
            }
            else
            {
                start = mid + 1;//2
            }
        }

        return start;
    }

    private int FindDuplicateBruteForce(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                {
                    return nums[i];
                }
            }
        }

        return 0;                
    }
}
