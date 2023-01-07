using JetBrains.Annotations;

namespace LeetCode._2526_Find_Consecutive_Integers_from_a_Data_Stream;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IDataStream Create(int value, int k)
    {
        return new DataStream1(value, k);
    }
}
