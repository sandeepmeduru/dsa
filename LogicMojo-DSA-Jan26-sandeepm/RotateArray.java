class Solution {
    static void rotateArr(int arr[], int d) {
        int n = arr.length;
        d = d % n;
        reverse(arr, 0, n - 1);
        reverse(arr, 0, n - d - 1);
        reverse(arr, n - d, n - 1);
    }
    
    private static void reverse(int[] arr, int start, int end)
    {
        while (start <= end)
        {
            int temp = arr[end];
            arr[end] = arr[start];
            arr[start] = temp;
            start++;
            end--;
        }
    }
}
