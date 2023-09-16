using JetBrains.Annotations;

namespace LeetCode._1282_Group_the_People_Given_the_Group_Size_They_Belong_To;

/// <summary>
/// https://leetcode.com/submissions/detail/1046316045/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> GroupThePeople(int[] groupSizes)
    {
        var n = groupSizes.Length;
        var sizeIndicesMap = Enumerable.Range(0, n).GroupBy(i => groupSizes[i])
            .ToDictionary(g => g.Key, g => g.ToArray());

        var ans = new List<IList<int>>();

        foreach (var (size, indices) in sizeIndicesMap)
        {
            var count = indices.Length / size;

            for (var i = 0; i < count; i++)
            {
                ans.Add(indices.Skip(i * size).Take(size).ToArray());
            }
        }

        return ans;
    }
}
