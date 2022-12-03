using JetBrains.Annotations;

namespace LeetCode._0155_Min_Stack;

/// <summary>
/// https://leetcode.com/problems/min-stack/submissions/848293212/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMinStack Create()
    {
        return new MinStack1();
    }
}
