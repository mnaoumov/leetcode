using JetBrains.Annotations;

namespace LeetCode._0632_Smallest_Range_Covering_Elements_from_K_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/912167175/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SmallestRange(IList<IList<int>> nums)
    {
        var set = new HashSet<int>();
        var skipBound = int.MaxValue;
        var resultLow = int.MinValue;
        var resultLength = int.MaxValue;

        foreach (var list in nums)
        {
            foreach (var low in list)
            {
                if (!set.Add(low))
                {
                    continue;
                }

                if (low >= skipBound)
                {
                    continue;
                }

                var high = low;

                var shouldSkip = false;

                foreach (var list2 in nums)
                {
                    var index = BinarySearch(list2, low);

                    if (index >= list2.Count)
                    {
                        skipBound = low;
                        shouldSkip = true;
                        break;
                    }

                    high = Math.Max(high, list2[index]);

                    var length = high - low;

                    if (length < resultLength || length == resultLength && low <= resultLow)
                    {
                        continue;
                    }

                    shouldSkip = true;
                    break;
                }

                if (shouldSkip)
                {
                    continue;
                }

                resultLength = high - low;
                resultLow = low;
            }
        }

        return new[] { resultLow, resultLow + resultLength };
    }

    private static int BinarySearch<T>(IList<T> list, T value) where T : IComparable<T>
    {
        var low = 0;
        var high = list.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            switch (list[mid].CompareTo(value))
            {
                case 0:
                    return mid;
                case < 0:
                    low = mid + 1;
                    break;
                default:
                    high = mid - 1;
                    break;
            }
        }

        return low;
    }
}
