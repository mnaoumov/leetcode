using JetBrains.Annotations;

namespace LeetCode._0352_Data_Stream_as_Disjoint_Intervals;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISummaryRanges Create()
    {
        return new SummaryRanges1();
    }
}
