using JetBrains.Annotations;

namespace LeetCode.Problems._2513_Minimize_the_Maximum_of_Two_Arrays;

[PublicAPI]
public interface ISolution
{
    public int MinimizeSet(int divisor1, int divisor2, int uniqueCnt1, int uniqueCnt2);
}
