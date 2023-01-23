using JetBrains.Annotations;

namespace LeetCode._0346_Moving_Average_from_Data_Stream;

/// <summary>
/// https://leetcode.com/submissions/detail/882824800/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMovingAverage Create(int size)
    {
        return new MovingAverage1(size);
    }
}
