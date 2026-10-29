namespace LeetCode.Problems._2844_Minimum_Operations_to_Make_a_Special_Number;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-361/submissions/detail/1039021869/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperations(string num)
    {
        var n = num.Length;

        var indicesMap = Enumerable.Range(0, n).GroupBy(i => num[i])
            .ToDictionary(g => g.Key, g => g.OrderBy(i => i).ToArray());

        var removeAllCount = indicesMap.ContainsKey('0') ? n - 1 : n;

        return new[] { "00", "25", "50", "75" }.Select(CountOperations).Min();

        int CountOperations(string ending)
        {
            var digit1 = ending[0];
            var digit2 = ending[1];

            var indices2 = indicesMap.GetValueOrDefault(digit2, Array.Empty<int>());

            if (indices2.Length == 0)
            {
                return removeAllCount;
            }

            var index2 = indices2[^1];

            var indices1 = indicesMap.GetValueOrDefault(digit1, Array.Empty<int>());
            const int noIndex = -1;
            var index1 = indices1.LastOrDefault(i => i < index2, noIndex);

            if (index1 == noIndex)
            {
                return removeAllCount;
            }

            return n - 2 - index1;
        }
    }
}
