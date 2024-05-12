using JetBrains.Annotations;

namespace LeetCode.Problems._2571_Minimum_Operations_to_Reduce_an_Integer_to_0;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-333/submissions/detail/900692522/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int n)
    {
        while (true)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
            }

            if ((n & 1) == 0)
            {
                n >>= 1;
            }
            else
            {
                return 1 + Math.Min(MinOperations(n + 1), MinOperations(n - 1));
            }
        }
    }
}
