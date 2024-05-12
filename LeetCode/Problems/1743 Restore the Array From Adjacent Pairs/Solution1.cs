using JetBrains.Annotations;

namespace LeetCode._1743_Restore_the_Array_From_Adjacent_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/1095659869/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] RestoreArray(int[][] adjacentPairs)
    {
        var numIndicesMap = new Dictionary<int, List<int>>();

        var n = adjacentPairs.Length + 1;

        for (var i = 0; i < n - 1; i++)
        {
            var pair = adjacentPairs[i];
            numIndicesMap.TryAdd(pair[0], new List<int>());
            numIndicesMap.TryAdd(pair[1], new List<int>());

            numIndicesMap[pair[0]].Add(i);
            numIndicesMap[pair[1]].Add(i);
        }

        var start = numIndicesMap.Keys.First(num => numIndicesMap[num].Count == 1);

        var num = start;
        var list = new List<int>();
        var processedIndices = new HashSet<int>();

        while (true)
        {
            list.Add(num);
            var indices = numIndicesMap[num];
            const int noIndex = -1;
            var index = indices.FirstOrDefault(index => !processedIndices.Contains(index), noIndex);

            if (index == noIndex)
            {
                break;
            }

            var pair = adjacentPairs[index];
            num = pair[0] == num ? pair[1] : pair[0];
            processedIndices.Add(index);
        }

        return list.ToArray();
    }
}
