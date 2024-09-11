namespace LeetCode.Problems._0763_Partition_Labels;

/// <summary>
/// https://leetcode.com/submissions/detail/935059481/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> PartitionLabels(string s)
    {
        var result = new List<int>();
        var lastIndices = new Dictionary<char, int>();
        var n = s.Length;

        for (var i = n - 1; i >= 0; i--)
        {
            var letter = s[i];
            lastIndices.TryAdd(letter, i);
        }

        var partitionStartIndex = 0;
        var partitionEndIndex = 0;

        for (var i = 0; i < n; i++)
        {
            var letter = s[i];
            partitionEndIndex = Math.Max(partitionEndIndex, lastIndices[letter]);

            if (partitionEndIndex != i)
            {
                continue;
            }

            result.Add(partitionEndIndex - partitionStartIndex + 1);
            partitionStartIndex = i + 1;
            partitionEndIndex = i + 1;
        }

        return result;
    }
}
