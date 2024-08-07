using JetBrains.Annotations;

namespace LeetCode.Problems._3245_Alternating_Groups_III;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public IList<int> NumberOfAlternatingGroups(int[] colors, int[][] queries)
    {
        var alternatingGroups = new List<(int start, int size)> { (0, 1) };

        var n = colors.Length;

        for (var i = 1; i < n; i++)
        {
            if (colors[i] != colors[i - 1])
            {
                var lastGroup = alternatingGroups[^1];
                alternatingGroups[^1] = (lastGroup.start, lastGroup.size + 1);
            }
            else
            {
                alternatingGroups.Add((i, 1));
            }
        }

        var groupSizeCounts = new Dictionary<int, int>();

        if (colors[^1] != colors[0] && alternatingGroups.Count > 1)
        {
            var lastGroup = alternatingGroups[^1];
            var firstGroup = alternatingGroups[0];
            alternatingGroups[^1] = (lastGroup.start, lastGroup.size + firstGroup.size);
            alternatingGroups.RemoveAt(0);
        }

        foreach (var alternatingGroup in alternatingGroups)
        {
            groupSizeCounts.TryAdd(alternatingGroup.size, 0);
            groupSizeCounts[alternatingGroup.size]++;
        }

        var m = queries.Length;
        var ans = new List<int>();

        var indexComparer = Comparer<(int start, int size)>.Create((a, b) => a.start.CompareTo(b.start));

        for (var i = 0; i < m; i++)
        {
            var query = queries[i];
            var queryType = query[0];

            switch (queryType)
            {
                case 1:
                    var size = query[1];

                    foreach (var (groupSize, count) in groupSizeCounts)
                    {
                        if (groupSize < size)
                        {
                            continue;
                        }

                        ans[i] += count * (groupSize - size + 1);
                    }

                    break;
                case 2:
                    var index = query[1];
                    var color = query[2];

                    if (colors[index] == color)
                    {
                        break;
                    }

                    colors[index] = color;

                    var groupIndex = alternatingGroups.BinarySearch((index, 0), indexComparer);

                    if (groupIndex < 0)
                    {
                        groupIndex = ~groupIndex - 1;
                    }

                    if (groupIndex == -1)
                    {
                        groupIndex = alternatingGroups.Count - 1;
                        index += n;
                    }

                    var group = alternatingGroups[groupIndex];

                    if (group.start == index)
                    {

                    }
                    else
                    {
                        alternatingGroups[groupIndex] = (group.start, index - group.start);
                        alternatingGroups.Insert(groupIndex + 1, (index, 1));
                        alternatingGroups.Insert(groupIndex + 2, (index + 1, group.start + group.size - 1 - index));
                    }



                    break;
            }
        }

        return ans;
    }
}
