using JetBrains.Annotations;

namespace LeetCode.Problems._2305_Fair_Distribution_of_Cookies;

/// <summary>
/// https://leetcode.com/submissions/detail/918903423/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DistributeCookies(int[] cookies, int k)
    {
        var result = int.MaxValue;
        var unfairness = 0;
        var cookiesCountPerKid = new int[k];
        Backtrack(0);
        return result;

        void Backtrack(int bagIndex)
        {
            if (bagIndex == cookies.Length)
            {
                result = unfairness;
                return;
            }

            var cookieCount = cookies[bagIndex];
            var previousUnfairness = unfairness;

            for (var kidIndex = 0; kidIndex < k; kidIndex++)
            {
                if (cookiesCountPerKid[kidIndex] + cookieCount > result)
                {
                    continue;
                }

                cookiesCountPerKid[kidIndex] += cookieCount;
                unfairness = Math.Max(unfairness, cookiesCountPerKid[kidIndex]);
                Backtrack(bagIndex + 1);
                cookiesCountPerKid[kidIndex] -= cookieCount;
                unfairness = previousUnfairness;
            }
        }
    }
}
