// User function Template for Java

class Solution {
    public static ArrayList<ArrayList<Integer>> getPairs(int[] arr) {
        Arrays.sort(arr);

        ArrayList<ArrayList<Integer>> ans = new ArrayList<ArrayList<Integer>>();
        int lastSeen = 0;

        int i = 0, j = arr.length - 1;
        while (i < j)
        {
            if (arr[i] + arr[j] == 0)
            {
                if (i > 0 && arr[i] == lastSeen)
                {
                    i++;
                    continue;
                }

                ans.add(new ArrayList<>(Arrays.asList(arr[i], arr[j])));
                lastSeen = arr[i];
                i++;
                j--;
            }
            else if (arr[i] + arr[j] < 0)
            {
                i++;
            }
            else
            {
                j--;
            }
        }
        
        return ans;
    }
}
