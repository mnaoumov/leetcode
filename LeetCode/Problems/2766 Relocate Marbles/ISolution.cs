using JetBrains.Annotations;

namespace LeetCode.Problems._2766_Relocate_Marbles;

[PublicAPI]
public interface ISolution
{
    public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo);
}
