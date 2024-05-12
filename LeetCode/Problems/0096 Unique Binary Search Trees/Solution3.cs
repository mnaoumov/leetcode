using JetBrains.Annotations;

namespace LeetCode._0096_Unique_Binary_Search_Trees;

/// <summary>
/// https://leetcode.com/submissions/detail/829306178/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int NumTrees(int n)
    {
        var dp = new int?[n + 1];

        return Get(n);

        int Get(int k)
        {
            if (dp[k] is not { } result)
            {
                dp[k] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (k is 0 or 1)
                {
                    return 1;
                }

                var result2 = 0;

                for (var i = 1; i <= k; i++)
                {
                    result2 += Get(i - 1) * Get(k - i);
                }

                return result2;
            }
        }
    }
}
