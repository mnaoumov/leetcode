namespace LeetCode.Problems._1762_Buildings_With_an_Ocean_View;

/// <summary>
/// https://leetcode.com/problems/buildings-with-an-ocean-view/submissions/2142068815/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindBuildings(int[] heights)
    {
        var set = new SortedSet<(int height, int index)>();

        for (var i = 0; i < heights.Length; i++)
        {
            set.Add((heights[i], i));
        }

        var list = new List<int>();

        for (var i = 0; i < heights.Length; i++)
        {
            set.Remove((heights[i], i));

            if (set.Count == 0 || set.Max.height < heights[i])
            {
                list.Add(i);
            }
        }

        return list.ToArray();
    }
}
