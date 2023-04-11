using JetBrains.Annotations;

namespace LeetCode._0706_Design_HashMap;

/// <summary>
/// https://leetcode.com/submissions/detail/931645022/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyHashMap Create()
    {
        return new MyHashMap1();
    }
}
