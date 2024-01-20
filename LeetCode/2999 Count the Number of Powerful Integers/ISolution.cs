using JetBrains.Annotations;

namespace LeetCode._2999_Count_the_Number_of_Powerful_Integers;

[PublicAPI]
public interface ISolution
{
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s);
}
