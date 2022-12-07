using JetBrains.Annotations;

namespace LeetCode._2484_Count_Palindromic_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/855811728/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution6 : ISolution
{
    public int CountPalindromes(string s)
    {
        var symbolsIndexMap = s.Select((symbol, index) => (symbol, index))
            .GroupBy(x => x.symbol, x => x.index)
            .ToDictionary(g => g.Key, g => g.OrderBy(x => x).ToArray());

        const int modulo = 1000000007;

        return A(0, s.Length - 1, 4);

        int A(int left, int right, int minDistance)
        {
            if (minDistance == 0)
            {
                return right - left + 1;
            }

            var result = 0;

            foreach (var indices in symbolsIndexMap.Values)
            {
                var (leftIndex, rightIndex) = Limit(indices, left, right);

                for (var i = leftIndex; i <= rightIndex; i++)
                {
                    var firstIndex = indices[i];

                    for (var j = i + 1; j <= rightIndex; j++)
                    {
                        var lastIndex = indices[j];

                        if (lastIndex - firstIndex < minDistance)
                        {
                            continue;
                        }

                        result = (result + A(firstIndex + 1, lastIndex - 1, minDistance - 2)) % modulo;
                    }
                }
            }

            return result;
        }
    }

    private static (int leftIndex, int rightIndex) Limit(int[] indices, int left, int right)
    {
        var leftIndex = Array.BinarySearch(indices, left);

        if (leftIndex < 0)
        {
            leftIndex = ~leftIndex;
        }

        var rightIndex = Array.BinarySearch(indices, right);

        if (rightIndex < 0)
        {
            rightIndex = ~rightIndex - 1;
        }

        return (leftIndex, rightIndex);
    }
}
