using JetBrains.Annotations;

namespace LeetCode._2719_Count_of_Integers;

[PublicAPI]
public interface ISolution
{
    public int Count(string num1, string num2, int min_sum, int max_sum);
}
