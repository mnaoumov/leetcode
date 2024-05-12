using JetBrains.Annotations;

namespace LeetCode.Problems._0319_Bulb_Switcher;

/// <summary>
/// https://leetcode.com/submissions/detail/940337713/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int BulbSwitch(int n) => (int) Math.Sqrt(n);
}
