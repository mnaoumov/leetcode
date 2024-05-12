using JetBrains.Annotations;

namespace LeetCode.Problems._0062_Unique_Paths;

/// <summary>
/// https://leetcode.com/submissions/detail/819536916/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int UniquePaths(int m, int n)
    {
        var cache = new int?[m, n];

        return Get(1, 1);

        int Get(int m1, int n1)
        {
            if (m1 > m || n1 > n)
            {
                return 0;
            }

            if (cache[m1 - 1, n1 - 1] is not { } result)
            {
                cache[m1 - 1, n1 - 1] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (m1 == m && n1 == n)
                {
                    return 1;
                }

                return Get(m1 + 1, n1) + Get(m1, n1 + 1);
            }
        }
    }
}
