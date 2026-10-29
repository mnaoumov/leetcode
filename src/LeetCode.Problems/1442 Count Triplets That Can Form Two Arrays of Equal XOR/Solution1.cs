namespace LeetCode.Problems._1442_Count_Triplets_That_Can_Form_Two_Arrays_of_Equal_XOR;

/// <summary>
/// https://leetcode.com/submissions/detail/1271921961/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountTriplets(int[] arr)
    {
        var n = arr.Length;
        var prefixXors = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixXors[i + 1] = prefixXors[i] ^ arr[i];
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                for (var k = j; k < n; k++)
                {
                    if (XorSubarray(i, j - 1) == XorSubarray(j, k))
                    {
                        ans++;
                    }
                }
            }
        }

        return ans;

        int XorSubarray(int fromIndex, int toIndex) => prefixXors[toIndex + 1] ^ prefixXors[fromIndex];
    }
}
