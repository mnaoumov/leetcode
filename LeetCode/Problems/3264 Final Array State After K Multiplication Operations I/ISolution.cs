using JetBrains.Annotations;

namespace LeetCode.Problems._100411_Final_Array_State_After_K_Multiplication_Operations_I;

[PublicAPI]
public interface ISolution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier);
}
