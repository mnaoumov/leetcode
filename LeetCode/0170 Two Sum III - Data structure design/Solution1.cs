using JetBrains.Annotations;

namespace LeetCode._0170_Two_Sum_III___Data_structure_design;

/// <summary>
/// https://leetcode.com/submissions/detail/882066597/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ITwoSum Create()
    {
        return new TwoSum1();
    }
}
