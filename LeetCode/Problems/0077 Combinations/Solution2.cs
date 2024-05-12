using JetBrains.Annotations;

namespace LeetCode.Problems._0077_Combinations;

/// <summary>
/// https://leetcode.com/submissions/detail/829058653/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        return Iterate(1, k).ToArray();

        IEnumerable<IList<int>> Iterate(int firstNumber, int itemCount)
        {
            if (itemCount == 0)
            {
                yield return new List<int>();
                yield break;
            }

            for (var i = firstNumber; i <= n + 1 - itemCount; i++)
            {
                foreach (var tailCombination in Iterate(i + 1, itemCount - 1))
                {
                    tailCombination.Insert(0, i);
                    yield return tailCombination;
                }
            }
        }
    }
}
