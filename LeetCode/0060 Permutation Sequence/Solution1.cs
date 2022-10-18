using System.Diagnostics;

using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0060_Permutation_Sequence;

/// <summary>
/// https://leetcode.com/submissions/detail/819486577/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string GetPermutation(int n, int k)
    {
        var factorialCache = new int?[n + 1];

        return GetItemsPermutation(Enumerable.Range(1, n).ToArray(), k - 1);

        string GetItemsPermutation(IList<int> items, int index)
        {
            if (items.Count == 1)
            {
                Debug.Assert(index == 0);
                return items[0].ToString();
            }

            var tailItemsCountFactorial = Factorial(items.Count - 1);
            var headIndex = index / tailItemsCountFactorial;

            var tailItems = items.ToList();
            tailItems.RemoveAt(headIndex);
            var tailIndex = index % tailItemsCountFactorial;
            return $"{items[headIndex]}{GetItemsPermutation(tailItems, tailIndex)}";
        }

        int Factorial(int m)
        {
            if (factorialCache[m] is not { } result)
            {
                factorialCache[m] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (m == 1)
                {
                    return 1;
                }

                return Factorial(m - 1) * m;
            }
        }
    }
}