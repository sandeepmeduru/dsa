// User function Template for Java

class Solution {
    void segregate0and1(int[] arr) {
        int i = 0, j = arr.length - 1;
        
        while (i < j)
        {
            if (arr[i] == 1)
            {
                swap(arr, i, j);
                j--;
            }
            else
            {
                i++;
            }
        }
    }
    
    void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
