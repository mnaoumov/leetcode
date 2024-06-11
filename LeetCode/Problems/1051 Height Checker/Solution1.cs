using JetBrains.Annotations;

namespace LeetCode.Problems._1051_Height_Checker;

/// <summary>
/// https://leetcode.com/submissions/detail/1283553164/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int HeightChecker(int[] heights)
    {
        var expected = heights.OrderBy(x => x).ToArray();
        var pairs = heights.Zip(expected, (height, expectedHeight) => (height, expectedHeight));
        return pairs.Count(p => p.height != p.expectedHeight);
    }
}
