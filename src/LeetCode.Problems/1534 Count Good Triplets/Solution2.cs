namespace LeetCode.Problems._1534_Count_Good_Triplets;

/// <summary>
/// https://leetcode.com/problems/count-good-triplets/submissions/1606154224/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        var ans = 0;
        var n =arr.Length;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (Math.Abs(arr[i] - arr[j]) > a)
                {
                    continue;
                }

                for (var k = j + 1; k < n; k++)
                {
                    if (Math.Abs(arr[j] - arr[k]) > b)
                    {
                        continue;
                    }

                    if (Math.Abs(arr[k] - arr[i]) > c)
                    {
                        continue;
                    }

                    ans++;
                }
            }
        }
        return ans;
    }
}
