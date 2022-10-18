// ReSharper disable All
using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0077_Combinations;

/// <summary>
/// https://leetcode.com/submissions/detail/821692492/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        return Combine(1, k).ToArray();

        IEnumerable<IList<int>> Combine(int firstNumber, int itemCount)
        {
            if (itemCount == 0)
            {
                yield return new List<int>();
                yield break;
            }

            for (var i = firstNumber; i <= n + 1 - itemCount; i++)
            {
                foreach (var tailCombination in Combine(i + 1, itemCount - 1))
                {
                    tailCombination.Insert(0, i);
                    yield return tailCombination;
                }
            }
        }
    }
}