using JetBrains.Annotations;

namespace LeetCode.Problems._2526_Find_Consecutive_Integers_from_a_Data_Stream;

[PublicAPI]
public interface ISolution
{
    public IDataStream Create(int value, int k);
}
