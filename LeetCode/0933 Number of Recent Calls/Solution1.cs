using JetBrains.Annotations;

namespace LeetCode._0933_Number_of_Recent_Calls;

/// <summary>
/// https://leetcode.com/submissions/detail/899443720/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IRecentCounter Create()
    {
        return new RecentCounter1();
    }
}
