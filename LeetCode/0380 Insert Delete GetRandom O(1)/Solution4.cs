using JetBrains.Annotations;

namespace LeetCode._0380_Insert_Delete_GetRandom_O_1_;

/// <summary>
/// https://leetcode.com/submissions/detail/851809316/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public IRandomizedSet Create()
    {
        return new RandomizedSet4();
    }
}
