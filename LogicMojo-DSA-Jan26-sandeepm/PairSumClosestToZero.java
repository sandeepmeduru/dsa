// User function Template for Java

class Solution {
    public static int closestToZero(int arr[], int n) {
        Arrays.sort(arr);
        
        int i = 0, j = n-1;
        int maxSum = Integer.MIN_VALUE-1;

        while (i < j)
        {
            int currentSum = arr[i] + arr[j];

            if (Math.abs(currentSum) < Math.abs(maxSum))
            {
                maxSum = currentSum;
            }
            else if (Math.abs(currentSum) == Math.abs(maxSum))
            {
                maxSum = Math.max(currentSum, maxSum);
            }
            
            if (Math.abs(arr[i]) > Math.abs(arr[j]))
            {
                i++;
            }
            else
            {
                j--;
            }
        }
        
        return maxSum;
    }
}

/*-66 -60 -8

-74 -68 0

-67 -65 -37 -21 -18 4

-63 -61 -33 -17 -14 0

1 2 3 4

0 3 4 5

-5 -4 3 6
-2 -1 0 1*/
