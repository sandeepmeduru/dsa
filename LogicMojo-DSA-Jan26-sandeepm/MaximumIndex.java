class Solution {

    int maxIndexDiff(int arr[]) {
        int n = arr.length;
        int[] prefixMin = new int[n];
        int[] prefixMax = new int[n];
        
        prefixMin[0] = arr[0];
        prefixMax[n-1] = arr[n-1];
        for (int i = 1; i < n; i++)
        {
            prefixMin[i] = Math.min(arr[i], prefixMin[i-1]);
            prefixMax[n-i-1] = Math.max(arr[n-i-1], prefixMax[n-i]);
        }
        
        int maxDiff = 0, i = 0, j = 0;
        while (i <= j && j < n)
        {
            if (prefixMin[i] <= prefixMax[j])
            {
                maxDiff = Math.max(j-i, maxDiff);
                j++;
            }
            else
            {
                i++;
            }
        }

        return maxDiff;
    }
}

/*0  1  2  3  4  5  6  7  8
34 8  10 3  2  80 30 33 1

34 8  8  3  2  2  2  2  1
80 80 80 80 80 80 33 33 1*/
