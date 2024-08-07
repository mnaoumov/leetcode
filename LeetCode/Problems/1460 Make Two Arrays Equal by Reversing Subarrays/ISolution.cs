using JetBrains.Annotations;

namespace LeetCode.Problems._1460_Make_Two_Arrays_Equal_by_Reversing_Subarrays;

[PublicAPI]
public interface ISolution
{
    public bool CanBeEqual(int[] target, int[] arr);
}
