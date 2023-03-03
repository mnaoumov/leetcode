using JetBrains.Annotations;

namespace LeetCode._2526_Find_Consecutive_Integers_from_a_Data_Stream;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-95/submissions/detail/873334371/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IDataStream Create(int value, int k)
    {
        return new DataStream1(value, k);
    }
}
