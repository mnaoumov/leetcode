using JetBrains.Annotations;

namespace LeetCode.Problems._2610_Convert_an_Array_Into_a_2D_Array_With_Conditions;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> FindMatrix(int[] nums);
}
