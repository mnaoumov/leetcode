namespace LeetCode.Problems._1840_Maximum_Building_Height;

/// <summary>
/// https://leetcode.com/problems/maximum-building-height/submissions/2039419962/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxBuilding(int n, int[][] restrictions)
    {
        var ids = new List<int> { 1 };
        var maxHeights = new Dictionary<int, int>
        {
            [1] = 0
        };

        foreach (var restriction in restrictions)
        {
            var id = restriction[0];
            var maxHeight = restriction[1];
            ids.Add(id);
            maxHeights[id] = maxHeight;
        }

        ids.Sort();

        if (maxHeights.TryAdd(n, int.MaxValue))
        {
            ids.Add(n);
        }

        for (var i = 1; i < ids.Count; i++)
        {
            var id = ids[i];
            var previousId = ids[i - 1];

            maxHeights[id] = Math.Min(maxHeights[id], maxHeights[previousId] + id - previousId);
        }

        for (var i = ids.Count - 2; i >= 1; i--)
        {
            var id = ids[i];
            var nextId = ids[i + 1];

            maxHeights[id] = Math.Min(maxHeights[id], maxHeights[nextId] + nextId - id);
        }

        var ans = 0;

        for (var i = 0; i < ids.Count - 1; i++)
        {
            var a = ids[i];
            var b = ids[i + 1];
            var x = maxHeights[a];
            var y = maxHeights[b];

            var x2 = x + b - a;

            if (x2 <= y)
            {
                maxHeights[b] = x2;
                ans = Math.Max(ans, x2);
            }
            else
            {
                var z = (y - x + b - a) / 2;
                ans = Math.Max(ans, x + z);
            }
        }

        return ans;
    }
}
