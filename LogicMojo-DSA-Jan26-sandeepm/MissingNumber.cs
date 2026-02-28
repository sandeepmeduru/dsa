public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length;

        for(int i = 0; i < n; i++)
        {
            int value = Math.Abs(nums[i]);
            if (value == n)
            {
                continue;
            }

            if (value == n+1)
            {
                nums[0] = -nums[0];
                continue;
            }

            nums[value] = nums[value] == 0 ? -(n+1) : -nums[value];
        }

        for(int i = 0; i < n; i++)
        {
            if (nums[i] >= 0)
            {
                return i;
            }
        }

        return n;
    }
}
