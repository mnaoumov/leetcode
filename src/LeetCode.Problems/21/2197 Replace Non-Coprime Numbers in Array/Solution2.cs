using System.Numerics;

namespace LeetCode.Problems._2197_Replace_Non_Coprime_Numbers_in_Array;

/// <summary>
/// https://leetcode.com/problems/replace-non-coprime-numbers-in-array/submissions/1772227490/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        var ans = new List<int>();

        foreach (var num in nums)
        {
            var combinedNum = num;
            while (true)
            {
                var lastValue = ans.Count > 0 ? ans[^1] : 1;
                var gcd = (int) BigInteger.GreatestCommonDivisor(combinedNum, lastValue);

                if (gcd == 1)
                {
                    ans.Add(combinedNum);
                    break;
                }

                combinedNum *= ans[^1] / gcd;
                ans.RemoveAt(ans.Count - 1);
            }
        }

        return ans;
    }
}
