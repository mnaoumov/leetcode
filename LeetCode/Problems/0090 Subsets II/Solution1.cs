namespace LeetCode.Problems._0090_Subsets_II;

/// <summary>
/// https://leetcode.com/submissions/detail/828253106/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        var countsDict = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var uniqueNums = countsDict.Keys.ToArray();

        return Get(0).ToArray();

        IEnumerable<IList<int>> Get(int index)
        {
            if (index >= uniqueNums.Length)
            {
                yield return Array.Empty<int>();
                yield break;
            }

            var num = uniqueNums[index];
            var count = countsDict[num];

            foreach (var nextSubset in Get(index + 1))
            {
                for (var i = 0; i <= count; i++)
                {
                    yield return Enumerable.Repeat(num, i).Concat(nextSubset).ToArray();
                }
            }
        }
    }
}
