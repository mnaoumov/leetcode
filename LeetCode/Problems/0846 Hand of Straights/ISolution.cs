using JetBrains.Annotations;

namespace LeetCode.Problems._0846_Hand_of_Straights;

[PublicAPI]
public interface ISolution
{
    public bool IsNStraightHand(int[] hand, int groupSize);
}
